namespace Iyzpay.NetCore.Request
{
    public class RetrieveApmRequest : BaseRequest
    {
        public string PaymentId { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("paymentId", PaymentId)
                .GetRequestString();
        }
    }
}