namespace Iyzpay.NetCore.Model
{
    public class BkmInstallmentPrice : IRequestStringConvertible
    {
        public int? InstallmentNumber { get; set; }
        public string TotalPrice { get; set; }

        public string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .Append("installmentNumber", InstallmentNumber)
                .AppendPrice("totalPrice", TotalPrice)
                .GetRequestString();
        }
    }
}