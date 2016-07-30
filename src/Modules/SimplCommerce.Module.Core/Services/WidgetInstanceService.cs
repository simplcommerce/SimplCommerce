using System;
using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public class WidgetInstanceService : IWidgetInstanceService
    {
        private IRepository<WidgetInstance> _widgetInstanceRepository;

        public WidgetInstanceService(IRepository<WidgetInstance> widgetInstanceRepository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
        }

        public IQueryable<WidgetInstance> GetPublished(long widgetZoneId)
        {
            return _widgetInstanceRepository.Query().Where(x => x.WidgetZoneId == widgetZoneId
            && x.PublishStart.HasValue && x.PublishStart.Value < DateTime.Now
            && (!x.PublishEnd.HasValue || x.PublishEnd.Value > DateTime.Now));
        }
    }
}
