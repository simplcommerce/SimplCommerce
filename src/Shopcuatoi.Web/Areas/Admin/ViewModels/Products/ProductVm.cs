using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopcuatoi.Web.Areas.Admin.ViewModels.Products
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public bool IsPublished { get; set; }

        public IList<long> CategoryIds { get; set; } = new List<long>();

        public IList<ProductAttributeVm> Attributes { get; set; } = new List<ProductAttributeVm>();

        public IList<ProductVariationVm> Variations { get; set; } = new List<ProductVariationVm>();
    }
}