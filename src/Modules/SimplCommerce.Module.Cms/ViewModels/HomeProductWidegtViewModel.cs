using SimplCommerce.Module.Catalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Cms.ViewModels
{
    public class HomeProductWidegtViewModel
    {
        public long Id { get; set; }

        public string WidgetName { get; set; }

        public HomeProductWidgetSetting Settings { get; set; }

        public IList<ProductThumbnail> Products { get; set; }
    
    }
}
