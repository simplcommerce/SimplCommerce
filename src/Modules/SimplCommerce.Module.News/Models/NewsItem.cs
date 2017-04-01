using System.Collections.Generic;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.News.Models
{
    public class NewsItem : Content
    {
        public string ShortContent { get; set; }

        public string FullContent { get; set; }

        public Media ThumbnailImage { get; set; }

        public IList<NewsItemCategory> Categories { get; set; } = new List<NewsItemCategory>();

        public void AddNewsItemCategory(NewsItemCategory category)
        {
            category.NewsItem = this;
            Categories.Add(category);
        }
    }
    
}
