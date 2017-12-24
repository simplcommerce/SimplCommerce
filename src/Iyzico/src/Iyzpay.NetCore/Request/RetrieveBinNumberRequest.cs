namespace Iyzpay.NetCore.Request
{
    public class RetrieveBinNumberRequest : BaseRequest
    {
        public string BinNumber { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("binNumber", BinNumber)
                .GetRequestString();
        }
    }
}