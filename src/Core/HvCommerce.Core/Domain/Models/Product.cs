using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HvCommerce.Core.Domain.Models
{
    public class Product : Content
    {
        public Product ()
        {
            Medias = new List<ProductMedia>();
            Variations = new List<ProductVariation>();
        }

        [StringLength(1000)]
        public string ShortDescription { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [StringLength(5000)]
        public string Specification { get; set; }

        public int DisplayOrder { get; set; }

        public virtual IList<ProductMedia> Medias { get; set; }

        public virtual IList<ProductVariation> Variations { get; set; } 
    }
}