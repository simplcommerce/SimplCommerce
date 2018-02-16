namespace Iyzpay.NetCore.Model
{
    public class PayoutCompletedTransaction
    {
        public string PaymentTransactionId { get; set; }
        public string PayoutAmount { get; set; }
        public string PayoutType { get; set; }
        public string SubMerchantKey { get; set; }
        public string Currency { get; set; }
    }
}