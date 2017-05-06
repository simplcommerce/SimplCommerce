using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductVm
    {
        public ProductVm()
        {
            IsPublished = true;
            IsCallForPricing = false;
            IsAllowToOrder = true;
            IsOutOfStock = false;
            Price = 0;
        }

        public long Id { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }

        public bool IsOutOfStock { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public bool IsPublished { get; set; }

        public bool IsFeatured { get; set; }

        public IList<long> CategoryIds { get; set; } = new List<long>();

        public IList<ProductAttributeVm> Attributes { get; set; } = new List<ProductAttributeVm>();

        public IList<ProductOptionVm> Options { get; set; } = new List<ProductOptionVm>();

        public IList<ProductVariationVm> Variations { get; set; } = new List<ProductVariationVm>();

        public string ThumbnailImageUrl { get; set; }

        public IList<ProductMediaVm> ProductImages { get; set; } = new List<ProductMediaVm>();

        public IList<ProductMediaVm> ProductDocuments { get; set; } = new List<ProductMediaVm>();

        public IList<long> DeletedMediaIds { get; set; } = new List<long>();

        public long? BrandId { get; set; }

        public List<ProductLinkVm> RelatedProducts { get; set; } = new List<ProductLinkVm>();

        public List<ProductLinkVm> CrossSellProducts { get; set; } = new List<ProductLinkVm>();
    }
}
