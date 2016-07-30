using System.Linq;
using SimplCommerce.Module.Cms.Models;

namespace SimplCommerce.Module.Cms.Services
{
    public interface IWidgetInstanceService
    {
        IQueryable<WidgetInstance> GetPublished(long widgetZoneId);
    }
}
