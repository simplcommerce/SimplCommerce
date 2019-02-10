using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Data
{
    public class NotificationsCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserNotification>().ToTable("Notifications_UserNotification");
        }
    }
}
