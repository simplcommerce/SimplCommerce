using System;
using Newtonsoft.Json;
using SimplCommerce.Module.Notifications.Helpers;

namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Extension methods for <see cref="NotificationSubscription"/>.
    /// </summary>
    public static class NotificationSubscriptionExtensions
    {
        /// <summary>
        /// Converts <see cref="NotificationSubscription"/> to <see cref="NotificationSubscriptionDto"/>.
        /// </summary>
        public static NotificationSubscriptionDto ToNotificationSubscriptionDto(this NotificationSubscription subscriptionInfo)
        {
            var entityType = string.IsNullOrEmpty(subscriptionInfo.EntityTypeAssemblyQualifiedName)
                ? null
                : Type.GetType(subscriptionInfo.EntityTypeAssemblyQualifiedName);

            return new NotificationSubscriptionDto
            {
                UserId = subscriptionInfo.UserId,
                NotificationName = subscriptionInfo.NotificationName,
                EntityType = entityType,
                EntityTypeName = subscriptionInfo.EntityTypeName,
                EntityId = string.IsNullOrEmpty(subscriptionInfo.EntityId) ? null : JsonConvert.DeserializeObject(subscriptionInfo.EntityId, EntityHelper.GetPrimaryKeyType(entityType)),
                CreatedOn = subscriptionInfo.CreatedOn
            };
        }
    }
}
