using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class PaymentPostAuth : PaymentResource
    {
        public static PaymentPostAuth Create(CreatePaymentPostAuthRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PaymentPostAuth>(options.BaseUrl + "/payment/postauth",
                GetHttpHeaders(request, options), request);
        }
    }
}