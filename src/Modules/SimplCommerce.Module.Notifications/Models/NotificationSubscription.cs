using System;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Used to store a notification subscription.
    /// </summary>
    public class NotificationSubscription : EntityBase
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public virtual long UserId { get; set; }

        /// <summary>
        /// Notification unique name.
        /// </summary>
        [MaxLength(NotificationScheme.MaxNotificationNameLength)]
        public virtual string NotificationName { get; set; }

        /// <summary>
        /// Gets/sets entity type name, if this is an entity level notification.
        /// It's FullName of the entity type.
        /// </summary>
        [MaxLength(NotificationScheme.MaxEntityTypeNameLength)]
        public virtual string EntityTypeName { get; set; }

        /// <summary>
        /// AssemblyQualifiedName of the entity type.
        /// </summary>
        [MaxLength(NotificationScheme.MaxEntityTypeAssemblyQualifiedNameLength)]
        public virtual string EntityTypeAssemblyQualifiedName { get; set; }

        /// <summary>
        /// Gets/sets primary key of the entity, if this is an entity level notification.
        /// </summary>
        [MaxLength(NotificationScheme.MaxEntityIdLength)]
        public virtual string EntityId { get; set; }

        public virtual DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Soft delete tag
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationSubscription"/> class.
        /// </summary>
        public NotificationSubscription()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationSubscription"/> class.
        /// </summary>
        public NotificationSubscription(long userId, string notificationName, EntityIdentifier entityIdentifier = null)
        {
            NotificationName = notificationName;
            UserId = userId;
            EntityTypeName = entityIdentifier?.Type.FullName;
            EntityTypeAssemblyQualifiedName = entityIdentifier?.Type.AssemblyQualifiedName;
            EntityId = entityIdentifier?.Id.ToJsonString();
        }
    }
}
