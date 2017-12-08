using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.PaymentPaypalExpress.ViewModels;

namespace SimplCommerce.Module.PaymentPaypalExpress.Controllers
{
    public class PaymentExpressController : Controller
    {
        private string _clientId = "";
        private string _clientSecret = "";

        public async Task<ActionResult> CreatePayment()
        {
            var accessToken = await GetAccessToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var paymentCreateRequest = new PaymentCreateRequest
            {
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
                            total = "30.03",
                            currency = "USD",
                            details = new Details
                            {
                                subtotal = "30.00",
                                tax = "0.00",
                                shipping = "0.03"
                            }
                        }
                    }
                },
                redirect_urls = new Redirect_Urls
                {
                    cancel_url = "http://localhost:49209/PaymentExpress/Cancel",
                    return_url = "http://localhost:49209/PaymentExpress/Success",
                }
            };

            var response = await httpClient.PostJsonAsync("https://api.sandbox.paypal.com/v1/payments/payment", paymentCreateRequest);
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic payment = JObject.Parse(responseBody);
            // Has to explicitly declare the type to be able to get the propery
            string paymentId = payment.id;
            return Ok(new { PaymentId = paymentId, Debug = responseBody });
        }

        public async Task<ActionResult> ExecutePayment(PaymentExecuteVm model)
        {
            var accessToken = await GetAccessToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var paymentExecuteRequest = new PaymentExecuteRequest
            {
                payer_id = model.payerID
            };

            var response = await httpClient.PostJsonAsync($"https://api.sandbox.paypal.com/v1/payments/payment/{model.paymentID}/execute", paymentExecuteRequest);
            var responseBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return Ok(new { status = "success" });
        }

        private async Task<string> GetAccessToken()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_clientId}:{_clientSecret}")));
            var requestBody = new StringContent("grant_type=client_credentials");
            requestBody.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync("https://api.sandbox.paypal.com/v1/oauth2/token", requestBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic token = JObject.Parse(responseBody);
            string accessToken = token.access_token;
            return accessToken;
        }
    }
}
