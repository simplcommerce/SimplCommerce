using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class ProductAttribute : Entity
    {
        public virtual ProductVariation ProductVariant { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}