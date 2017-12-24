namespace Iyzpay.NetCore.Request
{
    public class CreateApprovalRequest : BaseRequest
    {
        public string PaymentTransactionId { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("paymentTransactionId", PaymentTransactionId)
                .GetRequestString();
        }
    }
}