using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.ViewModels
{
    public class CountryForm
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code3 { get; set; }

        public bool IsBillingEnabled { get; set; }

        public bool IsShippingEnabled { get; set; }

        public bool IsCityEnabled { get;  set; }

        public bool IsZipCodeEnabled { get;  set; }

        public bool IsDistrictEnabled { get;  set; }
    }
}
