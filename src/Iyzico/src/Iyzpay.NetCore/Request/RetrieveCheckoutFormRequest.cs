namespace Iyzpay.NetCore.Request
{
    public class RetrieveCheckoutFormRequest : BaseRequest
    {
        public string Token { set; get; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("token", Token)
                .GetRequestString();
        }
    }
}