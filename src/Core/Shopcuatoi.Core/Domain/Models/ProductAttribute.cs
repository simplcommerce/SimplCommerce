using System.Collections.Generic;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class ProductAttribute : Entity
    {
        public string Name { get; set; }

        public long GroupId { get; set; }

        public virtual ProductAttributeGroup Group { get; set; }

        public virtual IList<ProductTemplate> ProductTemplates { get; protected set; } = new List<ProductTemplate>();
    }
}