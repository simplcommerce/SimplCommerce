using System;
using System.Linq;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace SimplCommerce.Cms.ApplicationServices
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
