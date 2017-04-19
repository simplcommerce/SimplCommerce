using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.News.ViewModels
{
    public class NewsItemThumbnail
    {
        public long Id { get; set; }

        public string ShortContent { get; set; }
        
        public string ImageUrl { get; set; }

        public DateTimeOffset PublishedOn { get; set; }

        public string SeoTitle { get; set; }
    }
}
