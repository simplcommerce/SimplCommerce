using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class ProductMedia : Entity
    {
        public virtual Product Product { get; set; }

        public virtual Media Media { get; set; }

        public int DisplayOrder { get; set; }
    }
}
