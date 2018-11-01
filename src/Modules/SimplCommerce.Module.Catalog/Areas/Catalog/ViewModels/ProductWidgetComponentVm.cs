using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductWidgetComponentVm
    {
        public long Id { get; set; }

        public string WidgetName { get; set; }

        public ProductWidgetSetting Setting { get; set; }

        public IList<ProductThumbnail> Products { get; set; }
    }
}
