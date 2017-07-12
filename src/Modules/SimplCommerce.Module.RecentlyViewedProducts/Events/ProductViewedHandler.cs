using MediatR;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.RecentlyViewedProducts.Models;

namespace SimplCommerce.Module.RecentlyViewedProducts.Events
{
    public class ProductViewedHandler : INotificationHandler<ActivityHappened>
    {
        private readonly IRepository<Activity> _activityRepository;

        public ProductViewedHandler(IRepository<Activity> activityRepository)
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
