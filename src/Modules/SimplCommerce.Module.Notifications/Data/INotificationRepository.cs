using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Data
{
    /// <summary>
    /// Used to store (persist) notifications.
    /// </summary>
    public interface INotificationRepository
    {
        /// <summary>
        /// Inserts a notification subscription.
        /// </summary>
        Task InsertSubscriptionAsync(NotificationSubscription subscription);

        /// <summary>
        /// Deletes a notification subscription.
        /// </summary>
        Task DeleteSubscriptionAsync(long userId, string notificationName, string entityTypeName, string entityId);

        /// <summary>
        /// Inserts a notification scheme.
        /// </summary>
        Task InsertNotificationSchemeAsync(NotificationScheme notification);

        /// <summary>
        /// Gets a notification scheme by Id, or returns null if not found.
        /// </summary>
        Task<NotificationScheme> GetNotificationSchemeOrNullAsync(long notificationId);

        /// <summary>
        /// Inserts a user notification.
        /// </summary>
        Task InsertUserNotificationAsync(UserNotification userNotification);

        /// <summary>
        /// Gets subscriptions for a notification.
        /// </summary>
        Task<List<NotificationSubscription>> GetSubscriptionsAsync(string notificationName, string entityTypeName, string entityId);

        /// <summary>
        /// Gets subscriptions for a user.
        /// </summary>
        Task<List<NotificationSubscription>> GetSubscriptionsAsync(long userId);

        /// <summary>
        /// Checks if a user subscribed for a notification
        /// </summary>
        Task<bool> IsSubscribedAsync(long userId, string notificationName, string entityTypeName, string entityId);

        /// <summary>
        /// Updates a user notification state.
        /// </summary>
        Task UpdateUserNotificationStateAsync(Guid userNotificationId, UserNotificationState state);

        /// <summary>
        /// Updates all notification states for a user.
        /// </summary>
        Task UpdateAllUserNotificationStatesAsync(long userId, UserNotificationState state);

        /// <summary>
        /// Deletes a user notification.
        /// </summary>
        Task DeleteUserNotificationAsync(Guid userNotificationId);

        /// <summary>
        /// Deletes all notifications of a user.
        /// </summary>
        Task DeleteAllUserNotificationsAsync(long userId);

        /// <summary>
        /// Gets notifications of a user.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="skipCount">Skip count.</param>
        /// <param name="maxResultCount">Maximum result count.</param>
        /// <param name="state">State</param>
        Task<List<UserNotificationWithNotificationDetail>> GetUserNotificationWithNotificationDetailsAsync(long userId, UserNotificationState? state = null, int skipCount = 0, int maxResultCount = int.MaxValue);

        /// <summary>
        /// Gets user notification count.
        /// </summary>
        Task<int> GetUserNotificationCountAsync(long userId, UserNotificationState? state = null);

        /// <summary>
        /// Gets a user notification.
        /// </summary>
        Task<UserNotificationWithNotificationDetail> GetUserNotificationWithNotificationDetailOrNullAsync(Guid userNotificationId);

        /// <summary>
        /// Inserts notification detail.
        /// </summary>
        Task InsertNotificationDetailAsync(NotificationDetail notificationDetail);

        /// <summary>
        /// Deletes the notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        Task DeleteNotificationAsync(NotificationScheme notification);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
