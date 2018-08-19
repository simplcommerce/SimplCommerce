using SimplCommerce.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Models
{
    public class Entity : EntityBase
    {
        [Required]
        [StringLength(250)]
        public string Slug { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }

        public EntityType EntityType { get; set; }
    }
}
