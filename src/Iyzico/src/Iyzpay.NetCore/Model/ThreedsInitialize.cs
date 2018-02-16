using Iyzpay.NetCore.Request;
using Newtonsoft.Json;

namespace Iyzpay.NetCore.Model
{
    public class ThreedsInitialize : IyzipayResource
    {
        [JsonProperty(PropertyName = "threeDSHtmlContent")]
        public string HtmlContent { get; set; }

        public static ThreedsInitialize Create(CreatePaymentRequest request, Options options)
        {
            var response = RestHttpClient.Create()
                .Post<ThreedsInitialize>(options.BaseUrl + "/payment/3dsecure/initialize",
                    GetHttpHeaders(request, options), request);

            if (response != null)
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            return response;
        }
    }
}