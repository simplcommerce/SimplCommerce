namespace Iyzpay.NetCore.Request
{
    public class CreateThreedsPaymentRequest : BaseRequest
    {
        public string PaymentId { get; set; }
        public string ConversationData { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("paymentId", PaymentId)
                .Append("conversationData", ConversationData)
                .GetRequestString();
        }
    }
}