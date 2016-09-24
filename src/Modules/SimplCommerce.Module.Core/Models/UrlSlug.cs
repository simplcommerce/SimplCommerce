using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class UrlSlug : Entity
    {
        public string Slug { get; set; }

        public long EntityId { get; set; }

        public long EntityTypeId { get; set; }

        public EntityType EntityType { get; set; }
    }
}
