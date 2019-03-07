using System;
using Newtonsoft.Json;
using SimplCommerce.Module.Notifications.Helpers;

namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Extension methods for <see cref="NotificationScheme"/>.
    /// </summary>
    public static class NotificationDetailExtensions
    {
        /// <summary>
        /// Converts <see cref="NotificationScheme"/> to <see cref="NotificationDetailDto"/>.
        /// </summary>
        public static NotificationDetailDto ToNotificationDetailDto(this NotificationDetail notificationDetail)
        {
            var entityType = string.IsNullOrEmpty(notificationDetail.EntityTypeAssemblyQualifiedName)
                ? null
                : Type.GetType(notificationDetail.EntityTypeAssemblyQualifiedName);

            return new NotificationDetailDto
            {
                Id = notificationDetail.Id,
                NotificationName = notificationDetail.NotificationName,
                Data = string.IsNullOrEmpty(notificationDetail.Data) ? null : JsonConvert.DeserializeObject(notificationDetail.Data, Type.GetType(notificationDetail.DataTypeName)) as NotificationData,
                EntityTypeName = notificationDetail.EntityTypeName,
                EntityType = entityType,
                EntityId = string.IsNullOrEmpty(notificationDetail.EntityId) ? null : JsonConvert.DeserializeObject(notificationDetail.EntityId, EntityHelper.GetPrimaryKeyType(entityType)),
                Severity = notificationDetail.Severity,
                CreatedOn = notificationDetail.CreatedOn
            };
        }
    }
}
