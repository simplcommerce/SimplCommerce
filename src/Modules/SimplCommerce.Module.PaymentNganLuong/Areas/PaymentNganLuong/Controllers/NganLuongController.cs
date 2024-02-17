using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentNganLuong.Models;
using SimplCommerce.Module.PaymentNganLuong.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentNganLuong.Areas.PaymentNganLuong.Controllers
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("PaymentNganLuong")]
    public class NganLuongController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IWorkContext _workContext;
        private readonly ICheckoutService _checkoutService;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private Lazy<NganLuongConfigForm> _setting;

        public NganLuongController(
            IOrderService orderService,
            IRepository<Order> orderRepository,
            IRepository<Payment> paymentRepository,
            ICheckoutService checkoutService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IHttpClientFactory httpClientFactory)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _checkoutService = checkoutService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _httpClientFactory = httpClientFactory;
            _setting = new Lazy<NganLuongConfigForm>(GetSetting());
        }

        [HttpGet("ngan-luong/payment-methods")]
        public IActionResult PaymentMethods()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPayment(string paymentOption, string bankCode, Guid checkoutId)
        {
            var currentUser = await _workContext.GetCurrentUser();

            var cart = await _checkoutService.GetCheckoutDetails(checkoutId);
            if (cart == null)
            {
                return NotFound();
            }

            var orderCreateResult = await _orderService.CreateOrder(checkoutId, "NganLuong", 0, OrderStatus.PendingPayment);

            if (!orderCreateResult.Success)
            {
                TempData["Error"] = orderCreateResult.Error;
                return Redirect("~/checkout/payment");
            }

            var order = orderCreateResult.Value;

            var rootUrl = Request.GetFullHostingUrlRoot();
            var paymentSubmitRequest = new PaymentSubmitRequest
            {
                MerchantId = _setting.Value.MerchantId,
                MerchantPassword = _setting.Value.MerchantPassword,
                ReceiverEmail =  _setting.Value.ReceiverEmail,
                OrderCode = order.Id.ToString(),
                TotalAmount = (int)order.OrderTotal,
                PaymentMethod = paymentOption,
                BankCode = bankCode,
                ReturnUrl = $"{rootUrl}/ngan-luong/result",
                CancelUrl = $"{rootUrl}/ngan-luong/cancel?orderCode={order.Id}",
                BuyerFullname = currentUser.FullName,
                BuyerEmail = currentUser.Email,
                BuyerMobile = currentUser.PhoneNumber
            };

            var httpClient = _httpClientFactory.CreateClient();
            var nganLuongUrl = _setting.Value.IsSandbox ? "https://sandbox.nganluong.vn:8088/nl35/checkout.api.nganluong.post.php" : "https://www.nganluong.vn/checkout.api.nganluong.post.php";
            var requestMesage = new HttpRequestMessage(HttpMethod.Post, nganLuongUrl)
            {
                Content = paymentSubmitRequest.MakePostContent()
            };
            var response = await httpClient.SendAsync(requestMesage);
            response.EnsureSuccessStatusCode();
            var contentString = await response.Content.ReadAsStringAsync();
            contentString = contentString.Replace("&", "&amp;");
            var xdoc = XDocument.Parse(contentString);
            var paymentSubmitResponse = xdoc.Descendants("result").Select(x => new PaymentSubmitResponse
            {
                ErrorCode = x.Element("error_code").Value,
                Token = x.Element("token").Value,
                Description = x.Element("description").Value,
                TimeLimit = x.Element("time_limit").Value,
                CheckoutUrl = x.Element("checkout_url").Value
            }).First();

            if(paymentSubmitResponse.ErrorCode == "00")
            {
                return Redirect(paymentSubmitResponse.CheckoutUrl);
            }
            else
            {
                string errorMessage = $"Error code: {paymentSubmitResponse.ErrorCode}, Description: {paymentSubmitResponse.Description}";
                await UpdatePaymentStatusError(order, errorMessage, paymentSubmitResponse.Token);
                TempData["Error"] = errorMessage;
                return Redirect($"~/checkout/error?orderId={order.Id}");
            }
        }

        [Route("ngan-luong/result")]
        public async Task<IActionResult>SubmitPaymentResult(PaymentSubmitReturn model)
        {
            var orderId = long.Parse(model.OrderCode);
            var order = await _orderRepository.Query().FirstOrDefaultAsync(x => x.Id == orderId);
            var user = await _workContext.GetCurrentUser();
            if (order.CustomerId != user.Id)
            {
                return Forbid();
            }

            if (order.OrderStatus != OrderStatus.PendingPayment)
            {
                return BadRequest("Invalid order state");
            }

            var paymentStatus = await GetPaymentStatus(model.Token);
            if(paymentStatus.ErrorCode == "00")
            {
                await UpdatePaymentStatusSuccess(order, model.Token);
                return Redirect($"~/checkout/success?orderId={orderId}");
            }
            else
            {
                var errorMessage = ErrorMessages.GetMessage(model.ErrorCode);
                await UpdatePaymentStatusError(order, errorMessage, model.Token);
                TempData["Error"] = errorMessage;
                return Redirect($"~/checkout/error?orderId={orderId}");
            }
        }

        [Route("ngan-luong/cancel")]
        public async Task<IActionResult> Cancel(long orderCode)
        {
            var orderId = orderCode;
            var order = await _orderRepository.Query().FirstOrDefaultAsync(x => x.Id == orderId);
            var user = await _workContext.GetCurrentUser();
            if(order.CustomerId != user.Id)
            {
                return Forbid();
            }

            if(order.OrderStatus != OrderStatus.PendingPayment)
            {
                return BadRequest("Invalid order state");
            }

            await UpdatePaymentStatusError(order, "Customer canceled", null);
            TempData["Error"] = "Thanh toán đã bị hủy.";
            return Redirect($"~/checkout/error?orderId={orderCode}");
        }

        private async Task<PaymentStatusResponse> GetPaymentStatus(string token)
        {
            var paymentStatusRequest = new PaymentStatusRequest(_setting.Value.MerchantId, _setting.Value.MerchantPassword, token);
            var httpClient = _httpClientFactory.CreateClient();
            var nganLuongUrl = _setting.Value.IsSandbox ? "https://sandbox.nganluong.vn:8088/nl35/service/order/check" : "https://www.nganluong.vn/service/order/check";
            var requestMesage = new HttpRequestMessage(HttpMethod.Post, nganLuongUrl)
            {
                Content = paymentStatusRequest.MakePostContent()
            };
            var response = await httpClient.SendAsync(requestMesage);
            response.EnsureSuccessStatusCode();
            var contentString = await response.Content.ReadAsStringAsync();
            var paymentStatusResponse = JsonConvert.DeserializeObject<PaymentStatusResponse>(contentString);
            return paymentStatusResponse;
        }

        private async Task UpdatePaymentStatusSuccess(Order order, string token)
        {
            var payment = new Payment()
            {
                OrderId = order.Id,
                PaymentFee = order.PaymentFeeAmount,
                Amount = order.OrderTotal,
                PaymentMethod = "NganLuong",
                CreatedOn = DateTimeOffset.UtcNow,
            };

            order.OrderStatus = OrderStatus.PaymentReceived;
            payment.Status = PaymentStatus.Succeeded;
            payment.GatewayTransactionId = token;

            _paymentRepository.Add(payment);
            await _paymentRepository.SaveChangesAsync();
        }

        private async Task UpdatePaymentStatusError(Order order, string errorMessage, string token)
        {
            var payment = new Payment()
            {
                OrderId = order.Id,
                PaymentFee = order.PaymentFeeAmount,
                Amount = order.OrderTotal,
                PaymentMethod = "NganLuong",
                CreatedOn = DateTimeOffset.UtcNow,
            };

            order.OrderStatus = OrderStatus.PaymentFailed;
            payment.Status = PaymentStatus.Failed;
            payment.GatewayTransactionId = token;
            payment.FailureMessage = errorMessage;

            _paymentRepository.Add(payment);
            await _paymentRepository.SaveChangesAsync();
        }

        private NganLuongConfigForm GetSetting()
        {
            var nganLuongPaymentProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.NganLuongPaymentProviderId);
            var nganLuongSetting = JsonConvert.DeserializeObject<NganLuongConfigForm>(nganLuongPaymentProvider.AdditionalSettings);
            return nganLuongSetting;
        }
    }
}
