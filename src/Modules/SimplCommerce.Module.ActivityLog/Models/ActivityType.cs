using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.ActivityLog.Models
{
    public class ActivityType : EntityBase
    {
        public ActivityType (long id)
        {
            Id = id;
        }

        public string Name { get; set; }
    }
}
