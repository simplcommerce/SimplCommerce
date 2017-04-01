using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductForm
    {
        public ProductVm Product { get; set; }

        public IFormFile ThumbnailImage { get; set; }

        public IList<IFormFile> ProductImages { get; set; } = new List<IFormFile>();

        public IList<IFormFile> ProductDocuments { get; set; } = new List<IFormFile>();
    }
}
