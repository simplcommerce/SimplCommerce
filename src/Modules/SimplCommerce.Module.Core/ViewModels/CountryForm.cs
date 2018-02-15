namespace SimplCommerce.Module.Core.ViewModels
{
    public class CountryForm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code2 { get; set; }

        public string Code3 { get; set; }

        public bool IsBillingEnabled { get; set; }

        public bool IsShippingEnabled { get; set; }

        public bool IsCityEnabled { get;  set; }

        public bool IsPostalCodeEnabled { get;  set; }

        public bool IsDistrictEnabled { get;  set; }
    }
}
