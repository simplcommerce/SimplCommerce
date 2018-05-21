using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class WidgetZone : EntityBase
    {
        public WidgetZone(long id)
        {
            Id = id;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
