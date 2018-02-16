namespace Iyzpay.NetCore.Request
{
    public class RetrieveSubMerchantRequest : BaseRequest
    {
        public string SubMerchantExternalId { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("subMerchantExternalId", SubMerchantExternalId)
                .GetRequestString();
        }
    }
}