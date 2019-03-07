using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Tax.Areas.Tax.ViewModels
{
    public class TaxRateForm
    {
        public long Id { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Tax Class is required")]
        public long TaxClassId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string CountryId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public decimal Rate { get; set; }

        public long? StateOrProvinceId { get; set; }

        public string ZipCode { get; set; }
    }
}
