using System;

namespace SimplCommerce.Module.Notifications.Jobs
{
    /// <summary>
    /// Arguments for <see cref="NotificationDistributionJob"/>.
    /// </summary>
    [Serializable]
    public class NotificationDistributionJobArgs
    {
        /// <summary>
        /// Notification Id.
        /// </summary>
        public long NotificationId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationDistributionJobArgs"/> class.
        /// </summary>
        public NotificationDistributionJobArgs(long notificationId)
        {
            NotificationId = notificationId;
        }
    }
}
