using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Core.Domain.Models
{
    public class ProductTemplate : Entity
    {
        [Required]
        public string Name { get; set; }

        public virtual IList<ProductAttribute> ProductAttributes { get; protected set; } = new List<ProductAttribute>();

        public void AddAttribute(ProductAttribute attribute)
        {
            ProductAttributes.Add(attribute);
        }
    }
}
