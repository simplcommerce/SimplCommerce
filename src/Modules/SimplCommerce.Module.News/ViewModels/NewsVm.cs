using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.News.ViewModels
{
    public class NewsVm
    {
        public NewsVm()
        {
            NewsByCategory = new NewsByCategoryVm();
            NewsCategory = new List<NewsCategoryVm>();
        }
        public NewsCategoryVm CurrentNewsCategory { get; set; }

        public NewsByCategoryVm NewsByCategory { get; set; }

        public IList<NewsCategoryVm> NewsCategory { get; set; }
    }
}
