using System;
using System.Threading.Tasks;
using MediatR;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.ActivityLog.Models;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.ActivityLog.Events
{
    public class EntityViewedHandler : IAsyncNotificationHandler<EntityViewed>
    {
        private readonly IRepository<Activity> _activityRepository;
        private readonly IWorkContext _workContext;
        private const long EntityViewedActivityTypeId = 1;

        public EntityViewedHandler(IRepository<Activity> activityRepository, IWorkContext workcontext)
        {
            _activityRepository = activityRepository;
            _workContext = workcontext;
        }

        public async Task Handle(EntityViewed notification)
        {
            var user = await _workContext.GetCurrentUser();
            var activity = new Activity
            {
                ActivityTypeId = EntityViewedActivityTypeId,
                EntityId = notification.EntityId,
                EntityTypeId = notification.EntityTypeId,
                UserId = user.Id,
                CreatedOn = DateTimeOffset.Now
            };

            _activityRepository.Add(activity);
        }
    }
}
