using System;

namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Represents a user subscription to a notification.
    /// </summary>
    public class NotificationSubscriptionDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Notification unique name.
        /// </summary>
        public string NotificationName { get; set; }

        /// <summary>
        /// Entity type.
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// Name of the entity type (including namespaces).
        /// </summary>
        public string EntityTypeName { get; set; }

        /// <summary>
        /// Entity Id.
        /// </summary>
        public object EntityId { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    }
}
