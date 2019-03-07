namespace SimplCommerce.Module.PaymentBraintree.Areas.PaymentBraintree.ViewModels
{
    public class BraintreeCheckoutForm
    {
        public string ClientToken { get; set; }

        public decimal Amount { get; set; }

        public string ISOCurrencyCode { get; set; }
    }
}
