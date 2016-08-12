using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductDetailVariation
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public IList<ProductDetailVariationOption> Options { get; protected set; } = new List<ProductDetailVariationOption>();
    }
}
