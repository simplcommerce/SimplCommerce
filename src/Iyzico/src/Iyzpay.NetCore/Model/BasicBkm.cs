using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class BasicBkm : BasicPaymentResource
    {
        public string Token { get; set; }
        public string CallbackUrl { get; set; }
        public string PaymentStatus { get; set; }

        public static BasicBkm Retrieve(RetrieveBkmRequest request, Options options)
        {
            return RestHttpClient.Create().Post<BasicBkm>(options.BaseUrl + "/payment/bkm/auth/detail/basic",
                GetHttpHeaders(request, options), request);
        }
    }
}