using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class SimpleProductWidgetComponentVm
    {
        public long Id { get; set; }

        public string WidgetName { get; set; }

        public SimpleProductWidgetSetting Setting { get; set; }

        public IList<ProductThumbnail> Products { get; set; } = new List<ProductThumbnail>();
    }
}
