using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Module.Tax.Areas.Tax.ViewModels
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
