using System.Collections.Generic;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.ViewModels
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

        public IList<ProductDetailVariationOption> Options { get; protected set; } = new List<ProductDetailVariationOption>();
    }
}
