namespace SimplCommerce.Module.PaymentStripe.ViewModels
{
    public class StripeCheckoutForm
    {
        public string PublicKey { get; set; }

        public int Amount { get; set; }

        public string ISOCurrencyCode { get; set; }
    }
}
