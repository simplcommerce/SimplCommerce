using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentMomo.Models;
using SimplCommerce.Module.PaymentMomo.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentMomo.Areas.PaymentMomo.Controllers
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("PaymentMomo")]
    public class MomoPaymentController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IWorkContext _workContext;
        private readonly ICheckoutService _checkoutService;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private Lazy<MomoPaymentConfigForm> _setting;

        public MomoPaymentController(
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
            _setting = new Lazy<MomoPaymentConfigForm>(GetSetting());
        }

        [HttpPost]
        public async Task<IActionResult> MomoCheckout(Guid checkoutId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            
            var cart = await _checkoutService.GetCheckoutDetails(checkoutId);
            if (cart == null)
            {
                return NotFound();
            }

            var orderCreateResult = await _orderService.CreateOrder(checkoutId, "MomoPayment", 0, OrderStatus.PendingPayment);

            if (!orderCreateResult.Success)
            {
                TempData["Error"] = orderCreateResult.Error;
                return Redirect("~/checkout/payment");
            }

            var rootUrl = Request.GetFullHostingUrlRoot();

            var paymentRequest = new PaymentSubmitRequest(
                 secretKey: _setting.Value.SecretKey,
                 partnerCode: _setting.Value.PartnerCode,
                 accessKey: _setting.Value.AccessKey,
                 amount: orderCreateResult.Value.OrderTotal,
                 orderId: orderCreateResult.Value.Id,
                 orderInfo: "",
                 returnUrl: $"{rootUrl}/momo/result",
                 notifyUrl: $"{rootUrl}/momo/notify",
                 extraData: ""
                );

            var httpClient = _httpClientFactory.CreateClient();
            var momoUrl = _setting.Value.IsSandbox ? "https://test-payment.momo.vn/gw_payment/transactionProcessor" : "https://payment.momo.vn/gw_payment/transactionProcessor";
            var response = await httpClient.PostAsync(momoUrl, paymentRequest, CreateCamelCaseFormater());
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<PaymentSubmitResponse>();
            if (result.Validate(_setting.Value.SecretKey))
            {
                return Redirect(result.PayUrl);
            }

            TempData["Error"] = result.LocalMessage;
            return Redirect($"~/checkout/error?orderId={orderCreateResult.Value.Id}");
        }

        [HttpGet("momo/result")]
        public async Task<IActionResult> Result(PaymentSubmitResult result)
        {
            if (!result.Validate(_setting.Value.SecretKey))
            {
                TempData["Error"] = result.LocalMessage;
                return Redirect("~/checkout/error");
            }

            var orderId = long.Parse(result.OrderId);
            var order = await _orderRepository.Query().FirstOrDefaultAsync(x => x.Id == orderId);

            var status = await UpdatePaymentStatus(order, result);
            if (status)
            {
                return Redirect($"~/checkout/success?orderId={orderId}");
            }
            else
            {
                TempData["Error"] = result.LocalMessage;
                return Redirect($"~/checkout/error?orderId={orderId}");
            }
        }

        [HttpPost("momo/notify")]
        public async Task<IActionResult> Notify([FromBody]PaymentSubmitResult result)
        {
            if (!result.Validate(_setting.Value.SecretKey))
            {
                throw new ApplicationException("Momo validation fail");
            }

            var orderId = long.Parse(result.OrderId);
            var order = await _orderRepository.Query().FirstOrDefaultAsync(x => x.Id == orderId);

            // Update status in case the redirect fail
            if(order != null && order.OrderStatus == OrderStatus.PendingPayment)
            {
                await UpdatePaymentStatus(order, result);
            }

            return Accepted();
        }

        public async Task<bool> UpdatePaymentStatus(Order order, PaymentSubmitResult paymentSubmitResult)
        {
            bool status = false;
            var payment = new Payment()
            {
                OrderId = order.Id,
                PaymentFee = order.PaymentFeeAmount,
                Amount = order.OrderTotal,
                PaymentMethod = "MomoPayment",
                CreatedOn = DateTimeOffset.UtcNow,
            };

            if (paymentSubmitResult.ErrorCode == 0)
            {
                order.OrderStatus = OrderStatus.PaymentReceived;
                payment.Status = PaymentStatus.Succeeded;
                payment.GatewayTransactionId = paymentSubmitResult.TransId;
                status = true;
            }
            else
            {
                order.OrderStatus = OrderStatus.PaymentFailed;
                payment.Status = PaymentStatus.Failed;
                payment.GatewayTransactionId = paymentSubmitResult.TransId;
                payment.FailureMessage = $"{paymentSubmitResult.Message} - {paymentSubmitResult.LocalMessage}";
                status = false;
            }

            _paymentRepository.Add(payment);
            await _paymentRepository.SaveChangesAsync();

            return status;
        }

        private async Task<StatusResponse> GetMomoPaymentStatus(long orderId)
        {
            var request = new StatusRequest
                (
                    secretKey: _setting.Value.SecretKey,
                    partnerCode: _setting.Value.PartnerCode,
                    accessKey: _setting.Value.AccessKey,
                    orderId: orderId
                );

            var httpClient = _httpClientFactory.CreateClient();
            var momoUrl = _setting.Value.IsSandbox ? "https://test-payment.momo.vn/gw_payment/transactionProcessor" : "https://payment.momo.vn/gw_payment/transactionProcessor";
            var response = await httpClient.PostAsync(momoUrl, request, CreateCamelCaseFormater());
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<StatusResponse>();
            return result;
        }

        private MomoPaymentConfigForm GetSetting()
        {
            var momoPaymentProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.MomoPaymentProviderId);
            var momoSetting = JsonConvert.DeserializeObject<MomoPaymentConfigForm>(momoPaymentProvider.AdditionalSettings);
            return momoSetting;
        }

        private JsonMediaTypeFormatter CreateCamelCaseFormater()
        {
            var formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };

            return formatter;
        }
    }
}
