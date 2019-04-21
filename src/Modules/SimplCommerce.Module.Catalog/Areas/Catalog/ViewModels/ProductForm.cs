using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductForm
    {
        public ProductVm Product { get; set; } = new ProductVm();

        public IFormFile ThumbnailImage { get; set; }

        public IList<IFormFile> ProductImages { get; set; } = new List<IFormFile>();

        public IList<IFormFile> ProductDocuments { get; set; } = new List<IFormFile>();

        public IEnumerable<VariationImageForm> VariationImages { get; set; } = new List<VariationImageForm>();
    }

    public class VariationImageForm
    {
        public string Key { get; set; }

        public IFormFile Image { get; set; }
    }
}
