using System;
using System.Collections.Generic;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class ProductVariation : Entity
    {
        private bool isDeleted;

        public ProductVariation()
        {
            CreatedOn = UpdatedOn = DateTime.UtcNow;
        }

        /// <summary>
        ///     The name is the combination of Attribute values
        /// </summary>
        public string Name { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string Sku { get; set; }

        public decimal PriceOffset { get; set; }

        public bool IsAllowOrder { get; set; }

        public string ReasonNotAllowOrder { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
                if (value)
                {
                    IsPublished = false;
                }
            }
        }

        public virtual User CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual User UpdatedBy { get; set; }

        public virtual IList<ProductOptionCombination> OptionCombinations { get; protected set; } = new List<ProductOptionCombination>();

        public void AddOptionCombination(ProductOptionCombination combination)
        {
            combination.Variation = this;
            OptionCombinations.Add(combination);
        }
    }
}