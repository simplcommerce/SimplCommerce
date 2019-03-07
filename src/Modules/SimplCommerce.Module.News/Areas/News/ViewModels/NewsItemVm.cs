using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.News.Areas.News.ViewModels
{
    public class NewsItemVm
    {
        public NewsItemVm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string ShortContent { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string FullContent { get; set; }

        public bool IsPublished { get; set; }

        public string ThumbnailImageUrl { get; set; }

        public IList<long> NewsCategoryIds { get; set; } = new List<long>();
    }
}
