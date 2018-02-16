using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class CheckoutFormInitialize : CheckoutFormInitializeResource
    {
        public static CheckoutFormInitialize Create(CreateCheckoutFormInitializeRequest request, Options options)
        {
            return RestHttpClient.Create().Post<CheckoutFormInitialize>(
                options.BaseUrl + "/payment/iyzipos/checkoutform/initialize/auth/ecom",
                GetHttpHeaders(request, options), request);
        }
    }
}