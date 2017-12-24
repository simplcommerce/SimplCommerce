using System.Collections.Generic;

namespace Iyzpay.NetCore.Model
{
    public class InstallmentDetail
    {
        public string BinNumber { get; set; }
        public string Price { get; set; }
        public string CardType { get; set; }
        public string CardAssociation { get; set; }
        public string CardFamilyName { get; set; }
        public int? Force3Ds { get; set; }
        public long? BankCode { get; set; }
        public string BankName { get; set; }
        public int? ForceCvc { get; set; }
        public List<InstallmentPrice> InstallmentPrices { get; set; }
    }
}