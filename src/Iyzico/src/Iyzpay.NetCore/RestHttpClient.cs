using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Iyzpay.NetCore
{
    public class RestHttpClient
    {
        static RestHttpClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public static RestHttpClient Create()
        {
            return new RestHttpClient();
        }

        public T Get<T>(string url)
        {
            var httpClient = new HttpClient();
            var httpResponseMessage = httpClient.GetAsync(url).Result;

            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        public T Post<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            var httpClient = new HttpClient();
            foreach (string key in headers.Keys)
                httpClient.DefaultRequestHeaders.Add(key, headers.Get(key));
            var httpResponseMessage = httpClient.PostAsync(url, JsonBuilder.ToJsonString(request)).Result;
            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        public T Delete<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            var httpClient = new HttpClient();
            foreach (string key in headers.Keys)
                httpClient.DefaultRequestHeaders.Add(key, headers.Get(key));
            var requestMessage = new HttpRequestMessage
            {
                Content = JsonBuilder.ToJsonString(request),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url)
            };
            var httpResponseMessage = httpClient.SendAsync(requestMessage).Result;
            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        public T Put<T>(string url, WebHeaderCollection headers, BaseRequest request)
        {
            var httpClient = new HttpClient();
            foreach (string key in headers.Keys)
                httpClient.DefaultRequestHeaders.Add(key, headers.Get(key));
            var httpResponseMessage = httpClient.PutAsync(url, JsonBuilder.ToJsonString(request)).Result;
            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }
    }
}