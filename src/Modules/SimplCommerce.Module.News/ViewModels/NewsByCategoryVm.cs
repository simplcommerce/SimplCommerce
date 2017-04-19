using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.News.ViewModels
{
    public class NewsByCategoryVm
    {
        public NewsByCategoryVm()
        {
            NewsItem = new List<NewsItemThumbnail>();
        }

        public long NewsCategoryId { get; set; }

        public int TotalNews { get; set; }

        public IList<NewsItemThumbnail> NewsItem { get; set; }
    }
}
