namespace SimplCommerce.Module.PaymentCoD.Models
{
    public class CoDSetting
    {
        public decimal? MinOrderValue { get; set; }

        public decimal? MaxOrderValue { get; set; }

        public decimal PaymentFee { get; set; }
    }
}
