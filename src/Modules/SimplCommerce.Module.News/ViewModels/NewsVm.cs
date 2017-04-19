using System.Collections.Generic;

namespace SimplCommerce.Module.News.ViewModels
{
    public class NewsVm
    {
        public NewsVm()
        {
            NewsCategory = new List<NewsCategoryVm>();
        }
        public NewsCategoryVm CurrentNewsCategory { get; set; }

        public IList<NewsCategoryVm> NewsCategory { get; set; }

        public IList<NewsItemThumbnail> NewsItem { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalItem { get; set; }
    }
}
