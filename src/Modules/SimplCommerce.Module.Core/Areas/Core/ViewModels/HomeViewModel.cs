using System.Collections.Generic;

namespace SimplCommerce.Module.Core.ViewModels
{
    public class HomeViewModel
    {
        public IList<WidgetInstanceViewModel> WidgetInstances { get; set; } = new List<WidgetInstanceViewModel>();
    }
}
