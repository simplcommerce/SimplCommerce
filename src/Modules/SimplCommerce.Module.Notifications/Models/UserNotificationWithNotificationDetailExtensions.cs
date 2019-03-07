namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Extension methods for <see cref="UserNotificationWithNotificationDetail"/>.
    /// </summary>
    public static class UserNotificationWithNotificationDetailExtensions
    {
        /// <summary>
        /// Converts <see cref="UserNotificationWithNotificationDetail"/> to <see cref="UserNotificationDto"/>.
        /// </summary>
        public static UserNotificationDto ToUserNotificationDto(this UserNotificationWithNotificationDetail userNotificationWithNotificationDetail)
        {
            return userNotificationWithNotificationDetail.UserNotification.ToUserNotificationDto(
                userNotificationWithNotificationDetail.NotificationDetail.ToNotificationDetailDto()
                );
        }
    }
}
