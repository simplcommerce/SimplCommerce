using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iyzpay.NetCore.Model
{
    public class PaymentResource : IyzipayResource
    {
        public string Price { get; set; }
        public string PaidPrice { get; set; }
        public int? Installment { get; set; }
        public string Currency { get; set; }
        public string PaymentId { get; set; }
        public string PaymentStatus { get; set; }
        public int? FraudStatus { get; set; }
        public string MerchantCommissionRate { get; set; }
        public string MerchantCommissionRateAmount { get; set; }
        public string IyziCommissionRateAmount { get; set; }
        public string IyziCommissionFee { get; set; }
        public string CardType { get; set; }
        public string CardAssociation { get; set; }
        public string CardFamily { get; set; }
        public string CardToken { get; set; }
        public string CardUserKey { get; set; }
        public string BinNumber { get; set; }
        public string BasketId { get; set; }

        [JsonProperty(PropertyName = "itemTransactions")]
        public List<PaymentItem> PaymentItems { get; set; }

        public string ConnectorName { get; set; }
        public string AuthCode { get; set; }
        public string Phase { get; set; }
    }
}