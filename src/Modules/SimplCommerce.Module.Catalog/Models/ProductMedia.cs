using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class ProductMedia : EntityBase
    {
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public long MediaId { get; set; }

        public virtual Media Media { get; set; }

        public int DisplayOrder { get; set; }
    }
}
