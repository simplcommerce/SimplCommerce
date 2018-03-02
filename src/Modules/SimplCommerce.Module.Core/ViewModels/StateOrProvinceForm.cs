using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.ViewModels
{
    public class StateOrProvinceForm
    {
        public long Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Country field is required.")]
        public long CountryId { get; set; }

        public string CountryCode { get; set; }

        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
