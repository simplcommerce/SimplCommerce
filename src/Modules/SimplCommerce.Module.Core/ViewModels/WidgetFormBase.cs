using System;

namespace SimplCommerce.Module.Core.ViewModels
{
    public class WidgetFormBase
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long WidgetZoneId { get; set; }

        public DateTimeOffset? PublishStart { get; set; }

        public DateTimeOffset? PublishEnd { get; set; }
    }
}
