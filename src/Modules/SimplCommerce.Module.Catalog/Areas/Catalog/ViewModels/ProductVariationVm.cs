using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductVariationVm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string Sku { get; set; }

        public string Gtin { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        // File input doesn't get bound on nested models
        // https://github.com/aspnet/Mvc/issues/4485
        // Workaround by moving file input to the top
        [BindNever]
        public IFormFile ThumbnailImage { get; set; }

        public string ThumbnailImageUrl { get; set; }

        [BindNever]
        public IList<IFormFile> NewImages { get; set; } = new List<IFormFile>();

        public IList<string> ImageUrls { get; set; } = new List<string>();

        public IList<ProductOptionCombinationVm> OptionCombinations { get; set; } =
            new List<ProductOptionCombinationVm>();
    }
}
