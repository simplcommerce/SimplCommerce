namespace SimplCommerce.Module.PaymentStripeV2.Areas.PaymentStripeV2.ViewModels
{
    public class StripeV2CheckoutForm
    {
        public string PublicKey { get; set; }

        public long Amount { get; set; }

        public string ISOCurrencyCode { get; set; }
    }
}
