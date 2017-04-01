using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.News.ViewModels
{
    public class NewsItemForm
    {
        public NewsItemVm NewsItem { get; set; }

        public IFormFile ThumbnailImage { get; set; }
    }
}
