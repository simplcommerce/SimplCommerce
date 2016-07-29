using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class ProductCategory : Entity
    {
        public bool IsFeaturedProduct { get; set; }

        public int DisplayOrder { get; set; }

        public long CategoryId { get; set; }

        public long ProductId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Product Product { get; set; }
    }
}
