namespace Iyzpay.NetCore.Request
{
    public class RetrieveTransactionsRequest : BaseRequest
    {
        public string Date { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("date", Date)
                .GetRequestString();
        }
    }
}