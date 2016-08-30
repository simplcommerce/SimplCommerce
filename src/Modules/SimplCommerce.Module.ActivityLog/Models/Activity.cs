using System;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.ActivityLog.Models
{
    public class Activity : Entity
    {
        public long ActivityTypeId { get; set; }

        public ActivityType ActivityType { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public long EntityId { get; set; }

        public long EntityTypeId { get; set; }
    }
}
