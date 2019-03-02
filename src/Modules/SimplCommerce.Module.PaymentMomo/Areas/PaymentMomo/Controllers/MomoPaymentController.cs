using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentMomo.Models;
using SimplCommerce.Module.PaymentMomo.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentMomo.Areas.PaymentMomo.Controllers
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class MomoPaymentController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IWorkContext _workContext;
        private readonly ICartService _cartService;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private Lazy<MomoPaymentConfigForm> _setting;

        public MomoPaymentController(
            IOrderService orderService,
            IRepository<Order> orderRepository,
            IRepository<Payment> paymentRepository,
            ICartService cartService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IHttpClientFactory httpClientFactory)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _cartService = cartService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _httpClientFactory = httpClientFactory;
            _setting = new Lazy<MomoPaymentConfigForm>(GetSetting());
        }
        public async Task<IActionResult> MomoCheckout()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            var orderCreateResult = await _orderService.CreateOrder(cart.Id, "Momo", 0, OrderStatus.PendingPayment);

            if (!orderCreateResult.Success)
            {
                TempData["Error"] = orderCreateResult.Error;
                return Redirect("~/checkout/payment");
            }

            var paymentRequest = new PaymentSubmitRequest(
                 secretKey: _setting.Value.SecretKey,
                 partnerCode: _setting.Value.PartnerCode,
                 accessKey: _setting.Value.AccessKey,
                 amount: orderCreateResult.Value.OrderTotal,
                 orderId: orderCreateResult.Value.Id,
                 orderInfo: "test",
                 returnUrl: "https://localhost:44388/momo/result",
                 notifyUrl: "http://demo.simplcommerce.com",
                 extraData: ""
                );

            var httpClient = _httpClientFactory.CreateClient();
            var formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };

            var response = await httpClient.PostAsync("https://test-payment.momo.vn/gw_payment/transactionProcessor", paymentRequest, formatter);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<PaymentSubmitResponse>();
            if (result.Validate(_setting.Value.SecretKey))
            {
                return Redirect(result.PayUrl);
            }

            TempData["Error"] = result.LocalMessage;
            return Redirect("~/checkout/payment");
        }

        [HttpGet("momo/result")]
        public async Task<IActionResult> Result(PaymentSubmitResult result)
        {
            if (!result.Validate(_setting.Value.SecretKey))
            {
                TempData["Error"] = result.LocalMessage;
                return Redirect("~/checkout/payment");
            }

            var orderId = long.Parse(result.OrderId);
            var order = await _orderRepository.Query().FirstOrDefaultAsync(x => x.Id == orderId);

            var payment = new Payment()
            {
                OrderId = order.Id,
                PaymentFee = order.PaymentFeeAmount,
                Amount = order.OrderTotal,
                PaymentMethod = "MomoPayment",
                CreatedOn = DateTimeOffset.UtcNow,
            };

            if (result.ErrorCode == "0")
            {
                order.OrderStatus = OrderStatus.PaymentReceived;
                payment.Status = PaymentStatus.Succeeded;
                payment.GatewayTransactionId = result.TransId;

                _paymentRepository.Add(payment);
                await _paymentRepository.SaveChangesAsync();
                return Redirect("~/checkout/congratulation");
            }
            else
            {
                order.OrderStatus = OrderStatus.PaymentFailed;
                payment.Status = PaymentStatus.Failed;
                payment.GatewayTransactionId = result.TransId;
                payment.FailureMessage = $"{result.Message} - {result.LocalMessage}";

                _paymentRepository.Add(payment);
                await _paymentRepository.SaveChangesAsync();
                TempData["Error"] = result.LocalMessage;
                return Redirect("~/checkout/payment");
            }
        }

        private MomoPaymentConfigForm GetSetting()
        {
            var momoPaymentProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.MomoPaymentProviderId);
            var momoSetting = JsonConvert.DeserializeObject<MomoPaymentConfigForm>(momoPaymentProvider.AdditionalSettings);
            return momoSetting;
        }
    }
}
