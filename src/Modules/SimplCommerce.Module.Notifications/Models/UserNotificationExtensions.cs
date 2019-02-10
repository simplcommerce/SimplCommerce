namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Extension methods for <see cref="UserNotification"/>.
    /// </summary>
    public static class UserNotificationExtensions
    {
        /// <summary>
        /// Converts <see cref="UserNotification"/> to <see cref="UserNotificationDto"/>.
        /// </summary>
        public static UserNotificationDto ToUserNotificationDto(this UserNotification userNotification, NotificationDetailDto notificationDetailDto)
        {
            return new UserNotificationDto
            {
                Id = userNotification.Id,
                Detail = notificationDetailDto,
                UserId = userNotification.UserId,
                State = userNotification.State,
            };
        }
    }
}
