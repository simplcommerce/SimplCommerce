namespace Iyzpay.NetCore.Request
{
    public class CreateCancelRequest : BaseRequest
    {
        public string PaymentId { get; set; }
        public string Ip { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("paymentId", PaymentId)
                .Append("ip", Ip)
                .Append("reason", Reason)
                .Append("description", Description)
                .GetRequestString();
        }
    }
}