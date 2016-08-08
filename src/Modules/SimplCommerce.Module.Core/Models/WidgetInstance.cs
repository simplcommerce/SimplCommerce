using System;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class WidgetInstance : Entity
    {
        public WidgetInstance()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTimeOffset? PublishStart { get; set; }

        public DateTimeOffset? PublishEnd { get; set; }

        public long WidgetId { get; set; }

        public Widget Widget { get; set; }

        public long WidgetZoneId { get; set; }

        public WidgetZone WidgetZone { get; set; }

        public int DisplayOrder { get; set; }

        public string Data { get; set; }

        public string HtmlData { get; set; }

        /// <summary>
        /// This property cannot be used to filter again DB because it don't exist in database
        /// </summary>
        public bool IsPublished
        {
            get
            {
                return PublishStart.HasValue && PublishStart.Value < DateTimeOffset.Now && (!PublishEnd.HasValue || PublishEnd.Value > DateTimeOffset.Now);
            }
        }
    }
}
