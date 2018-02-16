using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iyzpay.NetCore.Model
{
    public class ApmResource : IyzipayResource
    {
        public string RedirectUrl { get; set; }
        public string Price { get; set; }
        public string PaidPrice { get; set; }
        public string PaymentId { get; set; }
        public string MerchantCommissionRate { get; set; }
        public string MerchantCommissionRateAmount { get; set; }
        public string IyziCommissionRateAmount { get; set; }
        public string IyziCommissionFee { get; set; }
        public string BasketId { get; set; }
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "itemTransactions")]
        public List<PaymentItem> PaymentItems { get; set; }

        public string Phase { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string Bic { get; set; }
        public string PaymentPurpose { get; set; }
        public string Iban { get; set; }
        public string CountryCode { get; set; }
        public string Apm { get; set; }
        public string MobilePhone { get; set; }
        public string PaymentStatus { get; set; }
    }
}