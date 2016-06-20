using System.Collections.Generic;

namespace SimplCommerce.Web.ViewModels
{
    public class CarouselWidgetViewComponentVm
    {
        public long Id { get; set; }

        public int DataInterval { get; set; } = 6000;

        public IList<CarouselWidgetViewComponentItemVm> Items { get; set; } = new List<CarouselWidgetViewComponentItemVm>();
    }
}
