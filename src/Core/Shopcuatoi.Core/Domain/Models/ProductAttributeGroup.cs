using System.Collections.Generic;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class ProductAttributeGroup : Entity
    {
        public string Name { get; set; }

        public virtual IList<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}
