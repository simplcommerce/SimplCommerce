using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class ProductAttribute : EntityBase
    {
        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        public long GroupId { get; set; }

        public ProductAttributeGroup Group { get; set; }

        public IList<ProductTemplateProductAttribute> ProductTemplates { get; protected set; } = new List<ProductTemplateProductAttribute>();
    }
}
