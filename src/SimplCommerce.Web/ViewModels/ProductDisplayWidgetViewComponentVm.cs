using System.Collections.Generic;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Web.ViewModels.Catalog;

namespace SimplCommerce.Web.ViewModels
{
    public class ProductDisplayWidgetViewComponentVm
    {
        public long Id { get; set; }

        public string WidgetName { get; set; }

        public WidgetProductDisplaySetting Setting { get; set; }

        public IList<ProductThumbnail> Products { get; set; }
    }
}
