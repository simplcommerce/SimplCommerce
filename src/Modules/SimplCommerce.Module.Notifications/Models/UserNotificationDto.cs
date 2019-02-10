using System;

namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Represents a notification sent to a user.
    /// </summary>
    [Serializable]
    public class UserNotificationDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// User Id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Current state of the user notification.
        /// </summary>
        public UserNotificationState State { get; set; }

        /// <summary>
        /// The notification detail.
        /// </summary>
        public NotificationDetailDto Detail { get; set; }
    }
}
