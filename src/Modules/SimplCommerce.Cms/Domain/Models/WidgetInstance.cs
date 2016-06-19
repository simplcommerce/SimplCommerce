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

        public IList<WidgetInstanceProperty> WidgetProperties { get; protected set; } = new List<WidgetInstanceProperty>();

        public void AddProperty(WidgetInstanceProperty property)
        {
            property.WidgetInstance = this;
            WidgetProperties.Add(property);
        }

        public string GetProperyValue(string name)
        {
            var property = WidgetProperties.FirstOrDefault(x => x.PropertyName == name);
            if (property == null)
            {
                throw new KeyNotFoundException("Cannot find widget property " + name);
            }
            return property.PropertyValue;
        }

        public void SetProperyValue(string name, string value)
        {
            var property = WidgetProperties.FirstOrDefault(x => x.PropertyName == name);
            if (property == null)
            {
                WidgetProperties.Add(new WidgetInstanceProperty { PropertyName = name, PropertyValue = value, WidgetInstance = this });
            }
            else
            {
                property.PropertyValue = value;
            }
        }

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
