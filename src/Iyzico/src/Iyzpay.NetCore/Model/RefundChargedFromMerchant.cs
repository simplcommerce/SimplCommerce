using Iyzpay.NetCore.Request;

namespace Iyzpay.NetCore.Model
{
    public class RefundChargedFromMerchant : IyzipayResource
    {
        public string PaymentId { get; set; }
        public string PaymentTransactionId { get; set; }
        public string Price { get; set; }

        public static RefundChargedFromMerchant Create(CreateRefundRequest request, Options options)
        {
            return RestHttpClient.Create().Post<RefundChargedFromMerchant>(
                options.BaseUrl + "/payment/iyzipos/refund/merchant/charge", GetHttpHeaders(request, options), request);
        }
    }
}