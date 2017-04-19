using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.News.ViewModels
{
    public class NewsItemForm
    {
        public NewsItemForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SeoTitle { get; set; }

        [Required]
        public string ShortContent { get; set; }

        [Required]
        public string FullContent { get; set; }

        public bool IsPublished { get; set; }

        public string ThumbnailImageUrl { get; set; }

        public IList<long> NewsCategoryIds { get; set; } = new List<long>();

        public IFormFile ThumbnailImage { get; set; }
    }
}
