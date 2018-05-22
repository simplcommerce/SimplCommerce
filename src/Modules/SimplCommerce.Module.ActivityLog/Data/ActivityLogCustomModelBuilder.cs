using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.ActivityLog.Models;

namespace SimplCommerce.Module.ActivityLog.Data
{
    public class ActivityLogCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityType>().HasData(new ActivityType(1) { Name = "EntityView" });
        }
    }
}
