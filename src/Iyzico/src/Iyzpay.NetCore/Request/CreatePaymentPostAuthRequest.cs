namespace Iyzpay.NetCore.Request
{
    public class CreatePaymentPostAuthRequest : BaseRequest
    {
        public string PaymentId { get; set; }
        public string PaidPrice { get; set; }
        public string Ip { get; set; }
        public string Currency { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("paymentId", PaymentId)
                .Append("ip", Ip)
                .AppendPrice("paidPrice", PaidPrice)
                .Append("currency", Currency)
                .GetRequestString();
        }
    }
}