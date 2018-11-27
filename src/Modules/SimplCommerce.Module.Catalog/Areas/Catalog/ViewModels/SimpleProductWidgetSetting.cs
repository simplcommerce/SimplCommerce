using System.Collections.Generic;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class SimpleProductWidgetSetting
    {
        public IList<ProductLinkVm> Products { get; set; } = new List<ProductLinkVm>();
    }
}
