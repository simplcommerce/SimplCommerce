namespace Iyzpay.NetCore.Request
{
    public class CreateRefundRequest : BaseRequest
    {
        public string PaymentTransactionId { get; set; }
        public string Price { get; set; }
        public string Ip { get; set; }
        public string Currency { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("paymentTransactionId", PaymentTransactionId)
                .AppendPrice("price", Price)
                .Append("ip", Ip)
                .Append("currency", Currency)
                .Append("reason", Reason)
                .Append("description", Description)
                .GetRequestString();
        }
    }
}