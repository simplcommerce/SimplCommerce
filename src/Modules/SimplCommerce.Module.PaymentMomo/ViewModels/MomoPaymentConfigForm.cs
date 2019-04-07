namespace SimplCommerce.Module.PaymentMomo.ViewModels
{
    public class MomoPaymentConfigForm
    {
        public bool IsSandbox { get; set; }

        public string PartnerCode { get; set; }

        public string AccessKey { get; set; }

        public string SecretKey { get; set; }

        public decimal PaymentFee { get; set; }
    }
}
