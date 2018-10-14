using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Tax.Areas.Tax.ViewModels
{
    public class TaxRateImport
    {
        [Range(1, long.MaxValue, ErrorMessage = "Tax Class is required")]
        public long TaxClassId { get; set; }

        [Required]
        public string CountryId { get; set; }

        public string StateOrProvinceName { get; set; }

        public string ZipCode { get; set; }

        [Required]
        public decimal Rate { get; set; }
    }
}
