using System;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Used to store a user notification.
    /// </summary>
    [Serializable]
    public class UserNotification : EntityBaseWithTypedId<Guid>
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public virtual long UserId { get; set; }

        /// <summary>
        /// NotificationDetail Id.
        /// </summary>
        [Required]
        public virtual long NotificationDetailId { get; set; }

        /// <summary>
        /// Current state of the user notification.
        /// </summary>
        public virtual UserNotificationState State { get; set; }

        public virtual DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Soft delete tag
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        public UserNotification()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotification"/> class.
        /// </summary>
        /// <param name="create"></param>
        public UserNotification(Guid id)
        {
            Id = id;
            State = UserNotificationState.Unread;
        }
    }
}
