using MediatR;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.ActivityLog.Models;
using SimplCommerce.Module.Core.Events;

namespace SimplCommerce.Module.ActivityLog.Events
{
    public class ActivityHappenedHandler : INotificationHandler<ActivityHappened>
    {
        private readonly IRepository<Activity> _activityRepository;

        public ActivityHappenedHandler(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public void Handle(ActivityHappened notification)
        {
            var activity = new Activity
            {
                ActivityTypeId = notification.ActivityTypeId,
                EntityId = notification.EntityId,
                EntityTypeId = notification.EntityTypeId,
                CreatedOn = notification.TimeHappened
            };

            _activityRepository.Add(activity);
        }
    }
}
