using System.Collections.Generic;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Cms.ViewModels
{
    public class CarouselWidgetForm : WidgetFormBase
    {
        public IList<CarouselWidgetItemForm> Items = new List<CarouselWidgetItemForm>();
    }
}
