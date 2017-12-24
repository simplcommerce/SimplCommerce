using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class Disapproval : IyzipayResource
    {
        public string PaymentTransactionId { get; set; }

        public static Disapproval Create(CreateApprovalRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Disapproval>(options.BaseUrl + "/payment/iyzipos/item/disapprove",
                GetHttpHeaders(request, options), request);
        }
    }
}