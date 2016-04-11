using System.Collections.Generic;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class ProductTemplate : Entity
    {
        public string Name { get; set; }

        public IList<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
    }
}
