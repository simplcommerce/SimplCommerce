using System.Collections.Generic;
using System.Threading.Tasks;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Services
{
    /// <summary>
    /// Used to manage subscriptions for notifications.
    /// </summary>
    public interface INotificationSubscriptionManager
    {
        /// <summary>
        /// Subscribes to a notification for given user and notification.
        /// </summary>
        Task SubscribeAsync(long userId, string notificationName, EntityIdentifier entityIdentifier = null);

        /// <summary>
        /// Subscribes to all available notifications for given user.
        /// It does not subscribe entity related notifications.
        /// </summary>
        Task SubscribeToAllAvailableNotificationsAsync(long userId);

        /// <summary>
        /// Unsubscribes from a notification.
        /// </summary>
        Task UnsubscribeAsync(long userId, string notificationName, EntityIdentifier entityIdentifier = null);

        /// <summary>
        /// Gets all subscribtions for given notification.
        /// </summary>
        Task<List<NotificationSubscriptionDto>> GetSubscriptionsAsync(string notificationName, EntityIdentifier entityIdentifier = null);

        /// <summary>
        /// Gets subscribed notifications for a user.
        /// </summary>
        Task<List<NotificationSubscriptionDto>> GetSubscribedNotificationsAsync(long userId);

        /// <summary>
        /// Checks if a user subscribed for a notification.
        /// </summary>
        Task<bool> IsSubscribedAsync(long userId, string notificationName, EntityIdentifier entityIdentifier = null);
    }
}
