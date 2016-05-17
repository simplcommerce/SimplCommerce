using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Products
{
    public class ProductForm
    {
        public ProductViewModel Product { get; set; }

        public IFormFile ThumbnailImage { get; set; }

        public IList<IFormFile> ProductImages { get; set; } = new List<IFormFile>();

        public IList<IFormFile> File { get; set; } = new List<IFormFile>();
    }
}
