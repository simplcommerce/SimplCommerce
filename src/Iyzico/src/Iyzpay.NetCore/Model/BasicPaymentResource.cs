namespace Iyzpay.NetCore.Model
{
    public class BasicPaymentResource : IyzipayResource
    {
        public string Price { get; set; }
        public string PaidPrice { get; set; }
        public int? Installment { get; set; }
        public string Currency { get; set; }
        public string PaymentId { get; set; }
        public string MerchantCommissionRate { get; set; }
        public string MerchantCommissionRateAmount { get; set; }
        public string IyziCommissionFee { get; set; }
        public string CardType { get; set; }
        public string CardAssociation { get; set; }
        public string CardFamily { get; set; }
        public string CardToken { get; set; }
        public string CardUserKey { get; set; }
        public string BinNumber { get; set; }
        public string PaymentTransactionId { get; set; }
        public string AuthCode { get; set; }
        public string ConnectorName { get; set; }
        public string Phase { get; set; }
    }
}