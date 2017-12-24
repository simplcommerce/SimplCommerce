namespace Iyzpay.NetCore.Request
{
    public class DeleteCardRequest : BaseRequest
    {
        public string CardUserKey { get; set; }
        public string CardToken { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("cardUserKey", CardUserKey)
                .Append("cardToken", CardToken)
                .GetRequestString();
        }
    }
}