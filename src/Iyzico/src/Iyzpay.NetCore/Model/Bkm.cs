using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class Bkm : PaymentResource
    {
        public string Token { get; set; }
        public string CallbackUrl { get; set; }

        public static Bkm Retrieve(RetrieveBkmRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Bkm>(options.BaseUrl + "/payment/bkm/auth/detail",
                GetHttpHeaders(request, options), request);
        }
    }
}