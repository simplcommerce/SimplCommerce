using System;
using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Cms.Domain.Models
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

        public DateTime? PublishStart { get; set; }

        public DateTime? PublishEnd { get; set; }

        public long WidgetId { get; set; }

        public Widget Widget { get; set; }

        public WidgetZone WidgetZone { get; set; }

        public int DisplayOrder { get; set; }

        public string WidgetData { get; set; }

        /// <summary>
        /// This property cannot be used to filter again DB because it don't exist in database
        /// </summary>
        public bool IsPublished
        {
            get
            {
                return PublishStart.HasValue && PublishStart.Value < DateTime.Now && (!PublishEnd.HasValue || PublishEnd.Value > DateTime.Now);
            }
        }
    }
}
