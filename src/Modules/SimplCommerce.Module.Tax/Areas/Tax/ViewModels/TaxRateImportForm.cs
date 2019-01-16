using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Module.Tax.Areas.Tax.ViewModels
{
    public class TaxRateImportForm
    {
        public bool IncludeHeader { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string CsvDelimiter { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public IFormFile CsvFile { get; set; }
    }
}
