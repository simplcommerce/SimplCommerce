using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Tax.ViewModels
{
    public class TaxRateImportForm
    {
        public bool IncludeHeader { get; set; }

        [Required]
        public string CsvDelimiter { get; set; }

        [Required]
        public IFormFile CsvFile { get; set; }
    }
}
