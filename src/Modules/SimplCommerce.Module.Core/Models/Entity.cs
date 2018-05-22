using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class Entity : EntityBase
    {
        public string Slug { get; set; }

        public string Name { get; set; }

        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }

        public EntityType EntityType { get; set; }
    }
}
