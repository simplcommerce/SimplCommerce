using SimplCommerce.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Localization.Models
{
    public class Resource : EntityBase
    {
        [Required]
        [StringLength(450)]
        public string Key { get; set; }

        public string Value { get; set; }

        [Required]
        public string CultureId { get; set; }

        public Culture Culture { get; set; }
    }
}
