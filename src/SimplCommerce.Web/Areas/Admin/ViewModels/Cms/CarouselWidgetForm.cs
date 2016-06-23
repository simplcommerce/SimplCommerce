using System.Collections.Generic;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Cms
{
    public class CarouselWidgetForm : WidgetFormBase
    {
        public IList<CarouselWidgetItemForm> Items = new List<CarouselWidgetItemForm>();
    }
}
