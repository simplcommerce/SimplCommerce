using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Web.ViewModels.Catalog;

namespace SimplCommerce.Web.ViewModels
{
    public class HomeViewModel
    {
        public IList<ProductThumbnail> FeaturedProducts { get; set; } = new List<ProductThumbnail>();

        public IList<WidgetInstanceVm> WidgetInstances { get; set; } = new List<WidgetInstanceVm>();
    }
}
