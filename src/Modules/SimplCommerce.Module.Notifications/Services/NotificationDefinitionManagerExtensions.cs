using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Services
{
    /// <summary>
    /// Extension methods for <see cref="INotificationDefinitionManager"/>.
    /// </summary>
    public static class NotificationDefinitionManagerExtensions
    {
        /// <summary>
        /// Gets all available notification definitions for given user.
        /// </summary>
        /// <param name="notificationDefinitionManager">Notification definition manager</param>
        /// <param name="userId">User</param>
        public static IReadOnlyList<NotificationDefinition> GetAllAvailable(this INotificationDefinitionManager notificationDefinitionManager, long userId)
        {
            return AsyncHelper.RunSync(() => notificationDefinitionManager.GetAllAvailableAsync(userId));
        }
        /// <summary>
        /// Add Notification Definition Items Extensions
        /// </summary>
        /// <param name="app"></param>
        /// <param name="items"></param>
        public static void AddNotificationDefinitionItems(this IApplicationBuilder app, params NotificationDefinition[] items)
        {
            var notificationDefinitionManager = app.ApplicationServices.GetService<INotificationDefinitionManager>();
            notificationDefinitionManager.AddOrUpdate(items);
        }
    }
}
