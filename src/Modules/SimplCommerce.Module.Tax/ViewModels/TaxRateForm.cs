using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Tax.ViewModels
{
    public class TaxRateForm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Tax Class is required")]
        public long TaxClassId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Country is required")]
        public long CountryId { get; set; }

        [Required]
        public decimal Rate { get; set; }

        public long? StateOrProvinceId { get; set; }

        public string ZipCode { get; set; }
    }
}
