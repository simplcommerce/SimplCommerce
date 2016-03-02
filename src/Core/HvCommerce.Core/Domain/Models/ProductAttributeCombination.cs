using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class ProductAttributeCombination : Entity
    {
        public long VariationId { get; set; }

        public virtual ProductVariation Variation { get; set; }

        public long AttributeValueId { get; set; }

        public virtual ProductAttributeValue AttributeValue { get; set; }
    }
}