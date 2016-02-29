using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class UrlSlug : Entity
    {
        public string Slug { get; set; }

        public long EntityId { get; set; }

        public string EntityName { get; set; }
    }
}
