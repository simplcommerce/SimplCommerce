using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class PeccoInitialize : IyzipayResource
    {
        public string HtmlContent { get; set; }
        public string RedirectUrl { get; set; }
        public string Token { get; set; }
        public long? TokenExpireTime { get; set; }

        public static PeccoInitialize Create(CreatePeccoInitializeRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PeccoInitialize>(options.BaseUrl + "/payment/pecco/initialize",
                GetHttpHeaders(request, options), request);
        }
    }
}