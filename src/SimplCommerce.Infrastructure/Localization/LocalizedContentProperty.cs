using SimplCommerce.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Infrastructure.Localization
{
    public class LocalizedContentProperty : EntityBase
    {
        public long EntityId { get; set; }

        [StringLength(450)]
        public string EntityType { get; set; }

        [Required]
        public string CultureId { get; set; }

        public Culture Culture { get; set; }

        [Required]
        [StringLength(450)]
        public string ProperyName { get; set; }

        public string Value { get; set; }
    }
}
