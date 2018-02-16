using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class CheckoutFormInitializePreAuth : CheckoutFormInitializeResource
    {
        public static CheckoutFormInitializePreAuth Create(CreateCheckoutFormInitializeRequest request, Options options)
        {
            return RestHttpClient.Create().Post<CheckoutFormInitializePreAuth>(
                options.BaseUrl + "/payment/iyzipos/checkoutform/initialize/preauth/ecom",
                GetHttpHeaders(request, options), request);
        }
    }
}