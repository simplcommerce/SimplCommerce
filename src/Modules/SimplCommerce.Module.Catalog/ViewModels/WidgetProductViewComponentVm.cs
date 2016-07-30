using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class WidgetProductViewComponentVm
    {
        public long Id { get; set; }

        public string WidgetName { get; set; }

        public WidgetProductDisplaySetting Setting { get; set; }

        public IList<ProductThumbnail> Products { get; set; }
    }
}
