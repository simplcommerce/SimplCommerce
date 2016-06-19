using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Cms.Domain.Models
{
    public class WidgetInstanceProperty : Entity
    {
        public string PropertyName { get; set; }

        public string PropertyValue { get; set; }

        public WidgetInstance WidgetInstance { get; set; }
    }
}
