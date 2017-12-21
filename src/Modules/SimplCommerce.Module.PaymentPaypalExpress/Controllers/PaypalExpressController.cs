using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentPaypalExpress.Models;
using SimplCommerce.Module.PaymentPaypalExpress.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentPaypalExpress.Controllers
{
    public class PaypalExpressController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private Lazy<PaypalExpressConfigForm> _setting;

        public PaypalExpressController(
            ICartService cartService,
            IOrderService orderService,
            IWorkContext workContext,
            IRepository<PaymentProvider> paymentProviderRepository,
            IRepository<Payment> paymentRepository)
        {
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
            _setting = new Lazy<PaypalExpressConfigForm>(GetSetting());
        }

        public async Task<ActionResult> CreatePayment()
        {
            var accessToken = await GetAccessToken();
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(currentUser.Id);
            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);

            if (string.IsNullOrWhiteSpace(_setting.Value.ExperienceProfileId))
            {
                _setting.Value.ExperienceProfileId = await CreateExperienceProfile();
                var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.PaypalExpressProviderId);
                stripeProvider.AdditionalSettings = JsonConvert.SerializeObject(_setting.Value);
                await _paymentProviderRepository.SaveChangesAsync();
            }

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var paymentCreateRequest = new PaymentCreateRequest
            {
               // experience_profile_id = _setting.Value.ExperienceProfileId,
                intent = "sale",
                payer = new Payer
                {
                    payment_method = "paypal"
                },
                transactions = new Transaction[]
                {
                    new Transaction {
                        amount = new Amount
                        {
                            total = cart.OrderTotal.ToString(),
                            currency = regionInfo.ISOCurrencySymbol,
                            details = new Details
                            {
                                subtotal = cart.SubTotalWithDiscount.ToString(),
                                tax = cart.TaxAmount.ToString(),
                                shipping = cart.ShippingAmount.ToString()
                            }
                        }
                    }
                },
                redirect_urls = new Redirect_Urls
                {
                    cancel_url = "http://localhost:49209/PaypalExpress/Cancel",
                    return_url = "http://localhost:49209/PaypalExpress/Success",
                }
            };

            var response = await httpClient.PostJsonAsync($"https://api{_setting.Value.EnvironmentUrlPart}.paypal.com/v1/payments/payment", paymentCreateRequest);
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic payment = JObject.Parse(responseBody);
            // Has to explicitly declare the type to be able to get the propery
            string paymentId = payment.id;
            return Ok(new { PaymentId = paymentId, Debug = responseBody });
        }

        public async Task<ActionResult> ExecutePayment(PaymentExecuteVm model)
        {
            var accessToken = await GetAccessToken();
            var currentUser = await _workContext.GetCurrentUser();
            var order = await _orderService.CreateOrder(currentUser, "PaypalExpress");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var paymentExecuteRequest = new PaymentExecuteRequest
            {
                payer_id = model.payerID
            };

            var response = await httpClient.PostJsonAsync($"https://api{_setting.Value.EnvironmentUrlPart}.paypal.com/v1/payments/payment/{model.paymentID}/execute", paymentExecuteRequest);
            var responseBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            dynamic payPalPayment = JObject.Parse(responseBody);
            // Has to explicitly declare the type to be able to get the propery
            string payPalPaymentId = payPalPayment.id;

            var payment = new Payment()
            {
                OrderId = order.Id,
                Amount = order.OrderTotal,
                PaymentMethod = "Stripe",
                CreatedOn = DateTimeOffset.UtcNow,
                GatewayTransactionId = payPalPaymentId
            };

            order.OrderStatus = Orders.Models.OrderStatus.Processing;
            _paymentRepository.Add(payment);
            await _paymentRepository.SaveChangesAsync();

            return Ok(new { status = "success" });
        }

        private async Task<string> GetAccessToken()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_setting.Value.ClientId}:{_setting.Value.ClientSecret}")));
            var requestBody = new StringContent("grant_type=client_credentials");
            requestBody.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync($"https://api{_setting.Value.EnvironmentUrlPart}.paypal.com/v1/oauth2/token", requestBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic token = JObject.Parse(responseBody);
            string accessToken = token.access_token;
            return accessToken;
        }

        private async Task<string> CreateExperienceProfile()
        {
            var accessToken = await GetAccessToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var experienceRequest = new ExperienceProfile
            {
                name = "SimplCommerceProfile",
                input_fields = new InputFields
                {
                    no_shipping = 1
                }
            };
            var response = await httpClient.PostJsonAsync($"https://api{_setting.Value.EnvironmentUrlPart}.paypal.com/v1/payment-experience/web-profiles", experienceRequest);
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic experience = JObject.Parse(responseBody);
            // Has to explicitly declare the type to be able to get the propery
            return experience.id;
        }

        private PaypalExpressConfigForm GetSetting()
        {
            var paypalExpressProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.PaypalExpressProviderId);
            var paypalExpressSetting = JsonConvert.DeserializeObject<PaypalExpressConfigForm>(paypalExpressProvider.AdditionalSettings);
            return paypalExpressSetting;
        }
    }
}
