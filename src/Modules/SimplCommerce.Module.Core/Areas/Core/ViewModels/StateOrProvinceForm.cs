using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Areas.Core.ViewModels
{
    public class StateOrProvinceForm
    {
        public long Id { get; set; }

        [Required]
        public string CountryId { get; set; }

        public string CountryCode { get; set; }

        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
