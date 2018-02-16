namespace Iyzpay.NetCore.Request
{
    public class CreateCrossBookingRequest : BaseRequest
    {
        public string SubMerchantKey { get; set; }
        public string Price { get; set; }
        public string Reason { get; set; }
        public string Currency { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("subMerchantKey", SubMerchantKey)
                .AppendPrice("price", Price)
                .Append("reason", Reason)
                .Append("currency", Currency)
                .GetRequestString();
        }
    }
}