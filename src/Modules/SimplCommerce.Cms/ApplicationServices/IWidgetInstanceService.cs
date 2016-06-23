using SimplCommerce.Cms.Domain.Models;
using System.Linq;

namespace SimplCommerce.Cms.ApplicationServices
{
    public interface IWidgetInstanceService
    {
        IQueryable<WidgetInstance> GetPublished(long widgetZoneId);
    }
}
