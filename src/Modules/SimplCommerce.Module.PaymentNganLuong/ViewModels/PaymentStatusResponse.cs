using Newtonsoft.Json;

namespace SimplCommerce.Module.PaymentNganLuong.ViewModels
{
    public class PaymentStatusResponse
    {
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("data")]
        public PaymentStatusResponseData Data { get; set; }
    }

    public class PaymentStatusResponseData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("receiver_email")]
        public string ReceiverEmail { get; set; }

        [JsonProperty("order_code")]
        public string OrderCode { get; set; }

        [JsonProperty("total_amount")]
        public int TotalAmount { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("order_description")]
        public string OrderDescription { get; set; }

        [JsonProperty("tax_amount")]
        public decimal? TaxAmount { get; set; }

        [JsonProperty("discount_amount")]
        public decimal? DiscountAmount { get; set; }

        [JsonProperty("fee_shipping")]
        public decimal? FeeShipping { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }

        [JsonProperty("buyer_fullname")]
        public string BuyerFullname { get; set; }

        [JsonProperty("buyer_email")]
        public string BuyerEmail { get; set; }

        [JsonProperty("buyer_mobile")]
        public string BuyerMobile { get; set; }

        [JsonProperty("buyer_address")]
        public string BuyerAddress { get; set; }

        [JsonProperty("affiliate_code")]
        public string AffiliateCode { get; set; }

        [JsonProperty("transaction_status")]
        public string TransactionStatus { get; set; }

        [JsonProperty("transaction_id")]
        public string Transaction_Id { get; set; }
    }
}
