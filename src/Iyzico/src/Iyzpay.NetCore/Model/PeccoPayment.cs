using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class PeccoPayment : PaymentResource
    {
        public string Token { get; set; }

        public static PeccoPayment Create(CreatePeccoPaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PeccoPayment>(options.BaseUrl + "/payment/pecco/auth",
                GetHttpHeaders(request, options), request);
        }
    }
}