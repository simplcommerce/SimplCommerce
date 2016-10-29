using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class ProductLink : EntityBase
    {
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public long LinkedProductId { get; set; }

        public Product LinkedProduct { get; set; }

        public ProductLinkType LinkType { get; set; }
    }
}
