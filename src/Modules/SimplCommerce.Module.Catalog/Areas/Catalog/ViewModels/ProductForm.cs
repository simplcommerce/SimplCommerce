using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductForm
    {
        public ProductVm Product { get; set; }

        public IFormFile ThumbnailImage { get; set; }

        public IList<IFormFile> ProductImages { get; set; } = new List<IFormFile>();

        public IList<IFormFile> ProductDocuments { get; set; } = new List<IFormFile>();
    }
}
