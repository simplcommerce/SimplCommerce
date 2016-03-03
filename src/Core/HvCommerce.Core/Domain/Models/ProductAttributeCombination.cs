using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class ProductAttributeCombination : Entity
    {
        public long VariationId { get; set; }

        public virtual ProductVariation Variation { get; set; }

        public long AttributeId { get; set; }

        public virtual ProductAttribute Attribute { get; set; }

        public string Value { get; set; }
    }
}