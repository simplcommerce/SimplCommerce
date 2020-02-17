namespace SimplCommerce.Module.PaymentStripe.Areas.PaymentStripe.ViewModels
{
    public class StripeCheckoutForm
    {
        public string PublicKey { get; set; }

        public long Amount { get; set; }

        public string ISOCurrencyCode { get; set; }
    }
}
