namespace Iyzpay.NetCore.Request
{
    public class CreatePeccoPaymentRequest : BaseRequest
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