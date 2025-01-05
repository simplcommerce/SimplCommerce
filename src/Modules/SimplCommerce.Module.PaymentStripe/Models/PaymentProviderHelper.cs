namespace SimplCommerce.Module.PaymentStripe.Models;

public static class PaymentProviderHelper
{
    public static readonly string StripeProviderId = "Stripe";
}

public class StripeSettings
{
    public string SecretKey { get; set; }
    public string PublishableKey { get; set; }
}
