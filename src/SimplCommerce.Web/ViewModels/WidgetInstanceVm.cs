using SimplCommerce.Cms.Domain.Models;

namespace SimplCommerce.Web.ViewModels
{
    public class WidgetInstanceVm
    {
        public long Id { get; set; }

        public string ViewComponentName { get; set; }

        public WidgetZone WidgetZone { get; set; }

        public string WidgetData { get; set; }
    }
}
