using System.Collections.Generic;

namespace Iyzpay.NetCore.Model
{
    public class BkmInstallment : IRequestStringConvertible
    {
        public long? BankId { get; set; }
        public List<BkmInstallmentPrice> InstallmentPrices { get; set; }

        public string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .Append("bankId", BankId)
                .AppendList("installmentPrices", InstallmentPrices)
                .GetRequestString();
        }
    }
}