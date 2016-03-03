using System;
using System.Collections.Generic;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class ProductVariation : Entity
    {
        public ProductVariation()
        {
            CreatedOn = UpdatedOn = DateTime.UtcNow;
        }

        /// <summary>
        ///     The name is the combination of Attribute values
        /// </summary>
        public string Name { get; set; }

        public virtual Product Product { get; set; }

        public string Sku { get; set; }

        public decimal PriceOffset { get; set; }

        public bool IsAllowOrder { get; set; }

        public string ReasonNotAllowOrder { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public virtual User CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual User UpdatedBy { get; set; }

        public virtual IList<ProductAttributeCombination> AttributeCombinations { get; protected set; } = new List<ProductAttributeCombination>();

        public void AddAttributeCombination(ProductAttributeCombination combination)
        {
            combination.Variation = this;
            AttributeCombinations.Add(combination);
        }
    }
}