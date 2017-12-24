namespace Iyzpay.NetCore.Request
{
    public class RetrieveInstallmentInfoRequest : BaseRequest
    {
        public string BinNumber { get; set; }
        public string Price { get; set; }

        public override string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPkiRequestString())
                .Append("binNumber", BinNumber)
                .AppendPrice("price", Price)
                .GetRequestString();
        }
    }
}