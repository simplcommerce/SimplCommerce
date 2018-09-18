using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentPaypalExpress.Models;
using SimplCommerce.Module.PaymentPaypalExpress.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentPaypalExpress.Controllers
{
    public class PaypalExpressController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private Lazy<PaypalExpressConfigForm> _setting;
        private readonly IHttpClientFactory _httpClientFactory;

        public PaypalExpressController(
            ICartService cartService,
            IOrderService orderService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepository<Payment> paymentRepository,
            IHttpClientFactory httpClientFactory)
        {
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
            _setting = new Lazy<PaypalExpressConfigForm>(GetSetting());
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult> CreatePayment()
        {
            var hostingDomain = Request.Host.Value;
            var accessToken = await GetAccessToken();
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(currentUser.Id);
            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);
            var experienceProfileId = await CreateExperienceProfile(accessToken);

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var paypalAcceptedNumericFormatCulture = CultureInfo.CreateSpecificCulture("en-US");
            var paymentCreateRequest = new PaymentCreateRequest
            {
                experience_profile_id = experienceProfileId,
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
                            total = (cart.OrderTotal + CalculatePaymentFee(cart.OrderTotal)).ToString("N2", paypalAcceptedNumericFormatCulture),
                            currency = regionInfo.ISOCurrencySymbol,
                            details = new Details
                            {
                                handling_fee = CalculatePaymentFee(cart.OrderTotal).ToString("N2", paypalAcceptedNumericFormatCulture),
                                subtotal = cart.SubTotalWithDiscountWithoutTax.ToString("N2", paypalAcceptedNumericFormatCulture),
                                tax = cart.TaxAmount?.ToString("N2", paypalAcceptedNumericFormatCulture) ?? "0",
                                shipping = cart.ShippingAmount?.ToString("N2", paypalAcceptedNumericFormatCulture) ?? "0"
                            }
                        }
                    }
                },
                redirect_urls = new Redirect_Urls
                {
                    cancel_url = $"http://{hostingDomain}/PaypalExpress/Cancel", //Haven't seen it being used anywhere
                    return_url = $"http://{hostingDomain}/PaypalExpress/Success", //Haven't seen it being used anywhere
                }
            };

            var response = await httpClient.PostJsonAsync($"https://api{_setting.Value.EnvironmentUrlPart}.paypal.com/v1/payments/payment", paymentCreateRequest);
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic payment = JObject.Parse(responseBody);
            if (response.IsSuccessStatusCode)
            {
                string paymentId = payment.id;
                return Ok(new { PaymentId = paymentId });
            }

            return BadRequest(responseBody);
        }

        public async Task<ActionResult> ExecutePayment(PaymentExecuteVm model)
        {
            var accessToken = await GetAccessToken();
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(currentUser.Id);
            var orderCreateResult = await _orderService.CreateOrder(currentUser, "PaypalExpress", CalculatePaymentFee(cart.OrderTotal), OrderStatus.PendingPayment);
            if (!orderCreateResult.Success)
            {
                return BadRequest(orderCreateResult.Error);
            }

            var order = orderCreateResult.Value;
            var payment = new Payment()
            {
                OrderId = order.Id,
                PaymentFee = order.PaymentFeeAmount,
                Amount = order.OrderTotal,
                PaymentMethod = "Paypal Express",
                CreatedOn = DateTimeOffset.UtcNow,
            };

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var paymentExecuteRequest = new PaymentExecuteRequest
            {
                payer_id = model.payerID
            };

            var response = await httpClient.PostJsonAsync($"https://api{_setting.Value.EnvironmentUrlPart}.paypal.com/v1/payments/payment/{model.paymentID}/execute", paymentExecuteRequest);
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic responseObject = JObject.Parse(responseBody);
            if (response.IsSuccessStatusCode)
            {
                // Has to explicitly declare the type to be able to get the propery
                string payPalPaymentId = responseObject.id;
                payment.Status = PaymentStatus.Succeeded;
                payment.GatewayTransactionId = payPalPaymentId;
                _paymentRepository.Add(payment);
                order.OrderStatus = OrderStatus.PaymentReceived;
                await _paymentRepository.SaveChangesAsync();
                return Ok(new { status = "success" });
            }

            payment.Status = PaymentStatus.Failed;
            payment.FailureMessage = responseBody;
            _paymentRepository.Add(payment);
            order.OrderStatus = OrderStatus.PaymentFailed;
            await _paymentRepository.SaveChangesAsync();

            string errorName = responseObject.name;
            string errorDescription = responseObject.message;
            return BadRequest($"{errorName} - {errorDescription}");
        }

        private async Task<string> GetAccessToken()
        {
            var httpClient = _httpClientFactory.CreateClient();
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

        private async Task<string> CreateExperienceProfile(string accessToken)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var experienceRequest = new ExperienceProfile
            {
                name = $"simpl_{Guid.NewGuid()}",
                input_fields = new InputFields
                {
                    no_shipping = 1
                },
                temporary = true
            };
            var response = await httpClient.PostJsonAsync($"https://api{_setting.Value.EnvironmentUrlPart}.paypal.com/v1/payment-experience/web-profiles", experienceRequest);
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic experience = JObject.Parse(responseBody);
            // Has to explicitly declare the type to be able to get the propery
            string profileId = experience.id;
            return profileId;
        }

        private decimal CalculatePaymentFee(decimal total)
        {
            var percent = _setting.Value.PaymentFee;
            return (total / 100) * percent;
        }

        private PaypalExpressConfigForm GetSetting()
        {
            var paypalExpressProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.PaypalExpressProviderId);
            var paypalExpressSetting = JsonConvert.DeserializeObject<PaypalExpressConfigForm>(paypalExpressProvider.AdditionalSettings);
            return paypalExpressSetting;
        }
    }
}
