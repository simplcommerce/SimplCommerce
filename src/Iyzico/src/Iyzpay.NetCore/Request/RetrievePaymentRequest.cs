namespace Iyzpay.NetCore.Request
{
    public class RetrievePaymentRequest : BaseRequest
    {
        public string PaymentId { get; set; }
        public string PaymentConversationId { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("paymentId", PaymentId)
                .Append("paymentConversationId", PaymentConversationId)
                .GetRequestString();
        }
    }
}