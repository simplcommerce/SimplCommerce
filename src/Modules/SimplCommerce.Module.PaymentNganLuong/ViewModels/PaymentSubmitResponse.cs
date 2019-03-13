namespace SimplCommerce.Module.PaymentNganLuong.ViewModels
{
    public class PaymentSubmitResponse
    {
        public string ErrorCode { get; set; }

        public string Token { get; set; }

        public string Description { get; set; }

        public string TimeLimit { get; set; }

        public string CheckoutUrl { get; set; }
    }
}
