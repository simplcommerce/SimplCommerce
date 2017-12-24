using Iyzpay.NetCore.Request;
using Newtonsoft.Json;

namespace Iyzpay.NetCore.Model
{
    public class ThreedsInitializePreAuth : IyzipayResource
    {
        [JsonProperty(PropertyName = "threeDSHtmlContent")]
        public string HtmlContent { get; set; }

        public static ThreedsInitializePreAuth Create(CreatePaymentRequest request, Options options)
        {
            var response = RestHttpClient.Create().Post<ThreedsInitializePreAuth>(
                options.BaseUrl + "/payment/3dsecure/initialize/preauth", GetHttpHeaders(request, options), request);

            if (response != null)
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            return response;
        }
    }
}