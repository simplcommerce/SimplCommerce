using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Infrastructure.Localization
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