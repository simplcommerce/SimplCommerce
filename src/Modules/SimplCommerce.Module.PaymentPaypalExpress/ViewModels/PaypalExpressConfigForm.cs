namespace SimplCommerce.Module.PaymentPaypalExpress.ViewModels
{
    public class PaypalExpressConfigForm
    {
        public bool IsSandbox { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public decimal PaymentFee { get; set; }

        public string Environment => IsSandbox ? "sandbox" : "production";

        public string EnvironmentUrlPart => IsSandbox ? ".sandbox" : "";
    }
}
