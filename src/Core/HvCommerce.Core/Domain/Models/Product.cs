using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HvCommerce.Core.Domain.Models
{
    public class Product : Content
    {
        [StringLength(1000)]
        public string ShortDescription { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [StringLength(5000)]
        public string Specification { get; set; }

        public int DisplayOrder { get; set; }

        public Media ThumbnailImage { get; set; }

        public virtual IList<ProductMedia> Medias { get; set; } = new List<ProductMedia>();

        public virtual IList<ProductVariation> Variations { get; set; } = new List<ProductVariation>();

        public void AddMedia(ProductMedia media)
        {
            media.Product = this;
            Medias.Add(media);
        }
    }
}