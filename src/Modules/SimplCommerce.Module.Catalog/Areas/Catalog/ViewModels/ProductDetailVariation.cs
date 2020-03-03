using System.Collections.Generic;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductDetailVariation
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }

        public int StockQuantity { get; set; }

        public bool StockTrackingIsEnabled { get; set; }

        public CalculatedProductPrice CalculatedProductPrice { get; set; }

        public IList<MediaViewModel> Images { get; set; } = new List<MediaViewModel>();

        public IList<ProductDetailVariationOption> Options { get; protected set; } = new List<ProductDetailVariationOption>();
    }
}
