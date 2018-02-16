namespace Iyzpay.NetCore.Request
{
    public class RetrieveCardListRequest : BaseRequest
    {
        public string CardUserKey { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("cardUserKey", CardUserKey)
                .GetRequestString();
        }
    }
}