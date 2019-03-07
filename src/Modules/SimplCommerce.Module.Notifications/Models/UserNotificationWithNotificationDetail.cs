namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// A class contains a <see cref="Models.UserNotification"/> and related <see cref="NotificationScheme"/>.
    /// </summary>
    public class UserNotificationWithNotificationDetail
    {
        /// <summary>
        /// User notification.
        /// </summary>
        public UserNotification UserNotification { get; set; }

        /// <summary>
        /// Notification.
        /// </summary>
        public NotificationDetail NotificationDetail { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotificationWithNotificationDetail"/> class.
        /// </summary>
        public UserNotificationWithNotificationDetail(UserNotification userNotification, NotificationDetail notificationDetail)
        {
            UserNotification = userNotification;
            NotificationDetail = notificationDetail;
        }
    }
}
