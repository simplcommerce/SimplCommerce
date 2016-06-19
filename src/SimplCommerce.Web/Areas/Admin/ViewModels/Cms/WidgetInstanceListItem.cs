using System;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Cms
{
    public class WidgetInstanceListItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string WidgetType { get; set; }

        public DateTime CreatedOn { get; set; }

        public string EditUrl { get; set; }

        public string WidgetZone { get; set; }

        public DateTime? PublishStart { get; set; }

        public DateTime? PublishEnd { get; set; }
    }
}
