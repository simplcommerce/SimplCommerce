using System.Collections.Generic;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Core.Domain.Models
{
    public class ProductAttribute : Entity
    {
        public string Name { get; set; }

        public long GroupId { get; set; }

        public virtual ProductAttributeGroup Group { get; set; }

        public virtual IList<ProductTemplate> ProductTemplates { get; protected set; } = new List<ProductTemplate>();
    }
}