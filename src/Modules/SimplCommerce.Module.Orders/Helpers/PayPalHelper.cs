using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.PayViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Orders.Helpers
{
    public static class PayPalHelper
    {
        public static async Task<PaypalToken> CreateCredentials()
        {
            string uri = "https://api.sandbox.paypal.com/v1/payments/payment";
            string clientid = "ARjd1yw5Jntmwl3xYq9TlFoLJmAOUKAIvuxaCz4kkTdZehd3EHe0UVPq64tjvgrQSPnE4FN92XiagVOd";
            string secret = "ENNZlK_Ix5pLd5fd5uJuAnldStrtghpMppK2aDrwQIlng09tHx65OqFffSHnzb-eifAPd4ob8AhRdBhR";

            string oAuthCredentials = Convert.ToBase64String(Encoding.Default.GetBytes(clientid + ":" + secret));
            HttpClient client = new HttpClient();
            //construct request message
            var h_request = new HttpRequestMessage(HttpMethod.Post, uri);
            h_request.Headers.Authorization = new AuthenticationHeaderValue("Basic", oAuthCredentials);
            h_request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            h_request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));

            h_request.Content = new StringContent("grant_type=client_credentials", UTF8Encoding.UTF8, "application/x-www-form-urlencoded");

            try
            {
                HttpResponseMessage response = await client.SendAsync(h_request);

                //if call failed ErrorResponse created...simple class with response properties
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    var errResp = JsonConvert.DeserializeObject<PaypalToken>(error);
                    return errResp;
                    // throw new PayPalException { error_name = errResp.name, details = errResp.details, message = errResp.message };
                }

                var success = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PaypalToken>(success);
            }
            catch (Exception)
            {
                throw new HttpRequestException("Request to PayPal Service failed.");
            }

        }


        public static async Task<PaypalToken> CreatePayment(Order order)
        {
            string uri = "https://api.sandbox.paypal.com/v1/payments/payment";
            List<Transaction> tr = new List<Transaction>();
            {
                new Amount
                {
                    total = "22",
                    currency = "euro"
                };
            }
            PaymentVm paymentvm = new PaymentVm
            {
                intent = "sale",
                redirect_urls = new PaymentLinks { cancel_url = "", return_url = "" },
                payer = new Payer { payment_method = "paypal" },
                transactions = tr
            };
            return null;
        }

        public static bool IsNullable<T>(T obj)
        {
            if (obj == null) return true; // obvious
            Type type = typeof(T);
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }


        public static HttpClient GetPaypalHttpClient()
        {
            const string sandbox = "https://api.sandbox.paypal.com";

            var http = new HttpClient
            {
                BaseAddress = new Uri(sandbox),
                Timeout = TimeSpan.FromSeconds(30),
            };

            return http;
        }

        public static async Task<JObject> GetPayPalAccessTokenAsync(HttpClient http)
        {
            string clientid = "ARjd1yw5Jntmwl3xYq9TlFoLJmAOUKAIvuxaCz4kkTdZehd3EHe0UVPq64tjvgrQSPnE4FN92XiagVOd";
            string secret = "ENNZlK_Ix5pLd5fd5uJuAnldStrtghpMppK2aDrwQIlng09tHx65OqFffSHnzb-eifAPd4ob8AhRdBhR";

            byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes($"{clientid}:{secret}");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            };

            request.Content = new FormUrlEncodedContent(form);

            HttpResponseMessage response = await http.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var jo = JObject.Parse(content);
            return jo;
        }

        public static async Task<PayPalPaymentCreatedResponcse> CreatePaypalPaymentAsync(HttpClient http, string accessToken, string number)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v1/payments/payment");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var payment = JObject.FromObject(new
            {
                intent = "sale",
                redirect_urls = new
                {
                    return_url = "http://localhost:49209/payment/getid",
                    cancel_url = "http://localhost:49209/payment/canceled"
                },
                payer = new { payment_method = "paypal" },
                transactions = JArray.FromObject(new[]
                {
            new
            {
                amount = new
                {
                    total = 7.47,
                    currency = "USD"
                }
            }
        })
            });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await http.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            PayPalPaymentCreatedResponcse paypalPaymentCreated = JsonConvert.DeserializeObject<PayPalPaymentCreatedResponcse>(content);
            return paypalPaymentCreated;
        }

        public static async Task<PayPalPaymentExecutedResponse> ExecutePaypalPaymentAsync(HttpClient http, string accessToken, string paymentId, string payerId)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1/payments/payment/{paymentId}/execute");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var payment = JObject.FromObject(new
            {
                payer_id = payerId
            });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await http.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            PayPalPaymentExecutedResponse executedPayment = JsonConvert.DeserializeObject<PayPalPaymentExecutedResponse>(content);
            return executedPayment;
        }
    }
}
