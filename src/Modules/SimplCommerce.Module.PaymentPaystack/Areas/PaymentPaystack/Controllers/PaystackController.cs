using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentPaystack.Models;
using SimplCommerce.Module.PaymentPaystack.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentPaystack.Areas.PaymentPaystack.Controllers
{
    [Area("PaymentPaystack")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PaystackController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private Lazy<PaystackConfigForm> _setting;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICurrencyService _currencyService;

        public PaystackController(
            ICartService cartService,
            IOrderService orderService,
            IRepository<Order> orderRepository,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepository<Payment> paymentRepository,
            IHttpClientFactory httpClientFactory,
            ICurrencyService currencyService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _orderRepository = orderRepository;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
            _setting = new Lazy<PaystackConfigForm>(GetSetting());
            _httpClientFactory = httpClientFactory;
            _currencyService = currencyService;
        }

        public async Task<IActionResult> PaystackCheckout()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }
            var rootUrl = Request.GetFullHostingUrlRoot();

            var orderCreateResult = await _orderService.CreateOrder(cart.Id, "PaystackPayment", CalculatePaymentFee(cart.OrderTotal), OrderStatus.PendingPayment);
            var order = orderCreateResult.Value;
            var payment = new Payment()
            {
                OrderId = order.Id,
                PaymentFee = order.PaymentFeeAmount,
                Amount = order.OrderTotal,
                PaymentMethod = "Paystack",
                CreatedOn = DateTimeOffset.UtcNow,
            };
            var callback_url = $"{rootUrl}/paystack/result";

            if (!orderCreateResult.Success)
            {
                TempData["Error"] = orderCreateResult.Error;
                return Redirect("~/checkout/payment");
            }

            var uri = "https://api.paystack.co/transaction/initialize";

            var amount = (cart.OrderTotal + CalculatePaymentFee(cart.OrderTotal));

            JObject jsonObject = new JObject();
            jsonObject["email"] = currentUser.Email;
            jsonObject["amount"] = amount.ToString();
            jsonObject["reference"] = payment.OrderId;
            jsonObject["callback_url"] = callback_url;

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", _setting.Value.ClientSecret));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var json = httpClient.PostAsync(uri, content).Result.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject(json);
            var _modal = JsonConvert.DeserializeObject<PaystackResponseModel>(result.ToString());
            string redirectUrl;
            try
            {
                redirectUrl = _modal.Data.Authorization_url;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            if (_modal.Status)
            {
                return Redirect(redirectUrl);
            }
            
            TempData["Error"] = "Failed to Initialise Transaction";
            return Redirect($"~/checkout/error?orderId={orderCreateResult.Value.Id}");
        }

        [HttpGet("paystack/result")]
        public async Task<IActionResult> Result(string reference)
        {
            var orderId = long.Parse(reference);
            var order = await _orderRepository.Query().FirstOrDefaultAsync(x => x.Id == orderId);

            if (!string.IsNullOrEmpty(reference))
            {
                VerifyPayStackResponseModel responseModel = new VerifyPayStackResponseModel();

                var uri = "https://api.paystack.co/transaction/verify/" + reference;


                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", _setting.Value.ClientSecret));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = httpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
                responseModel = JsonConvert.DeserializeObject<VerifyPayStackResponseModel>(content);

                var status = await UpdatePaymentStatus(order, responseModel);

                if (status)
                {
                    return Redirect($"~/checkout/success?orderId={orderId}");
                }
                else
                {
                    TempData["Error"] = "Payment Verification Failed";
                    return Redirect($"~/checkout/error?orderId={orderId}");
                }
            }
            else
            {
                TempData["Error"] = "No reference code passed";
                return Redirect("~/checkout/error");
            }
        }
        public async Task<bool> UpdatePaymentStatus(Order order, VerifyPayStackResponseModel responseModel)
        {
            bool status = false;
            var payment = new Payment()
            {
                OrderId = order.Id,
                PaymentFee = order.PaymentFeeAmount,
                Amount = order.OrderTotal,
                PaymentMethod = "Paystack",
                CreatedOn = DateTimeOffset.UtcNow,
            };

            if (responseModel.Data.Status.ToLower() == "success")
            {
                order.OrderStatus = OrderStatus.PaymentReceived;
                payment.Status = PaymentStatus.Succeeded;
                payment.GatewayTransactionId = responseModel.Data.Gateway_response;
                status = true;
            }
            else
            {
                order.OrderStatus = OrderStatus.PaymentFailed;
                payment.Status = PaymentStatus.Failed;
                payment.GatewayTransactionId = responseModel.Data.Gateway_response;
                payment.FailureMessage = responseModel.Data.Gateway_response;
                status = false;
            }

            _paymentRepository.Add(payment);
            await _paymentRepository.SaveChangesAsync();

            return status;
        }

        private PaystackConfigForm GetSetting()
        {
            var paystackProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.PaystackProviderId);
            var paystackSetting = JsonConvert.DeserializeObject<PaystackConfigForm>(paystackProvider.AdditionalSettings);
            return paystackSetting;
        }
        private decimal CalculatePaymentFee(decimal total)
        {
            var percent = _setting.Value.PaymentFee;
            return (total / 100) * percent;
        }


    }
}
