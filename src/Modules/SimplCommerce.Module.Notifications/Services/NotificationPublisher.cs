using System;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Module.HangfireJobs.Services;
using SimplCommerce.Module.Notifications.Data;
using SimplCommerce.Module.Notifications.Jobs;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Services
{
    /// <summary>
    /// Implements <see cref="INotificationPublisher"/>.
    /// </summary>
    public class NotificationPublisher : INotificationPublisher
    {
        public const int MaxUserCountToDirectlyDistributeANotification = 5;

        private readonly INotificationRepository _notificationRepository;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly INotificationDistributer _notificationDistributer;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationPublisher"/> class.
        /// </summary>
        public NotificationPublisher(
            INotificationRepository notificationRepository,
            IBackgroundJobManager backgroundJobManager,
            INotificationDistributer notificationDistributer)
        {
            _notificationRepository = notificationRepository;
            _backgroundJobManager = backgroundJobManager;
            _notificationDistributer = notificationDistributer;
        }

        //Create EntityIdentifier includes entityType and entityId.
        /// <inheritdoc />
        public virtual async Task PublishAsync(
            string notificationName,
            NotificationData data = null,
            EntityIdentifier entityIdentifier = null,
            NotificationSeverity severity = NotificationSeverity.Info,
            long[] userIds = null,
            long[] excludedUserIds = null)
        {
            if (notificationName.IsNullOrEmpty())
            {
                throw new ArgumentException("NotificationName can not be null or whitespace!", nameof(notificationName));
            }

            var notificationScheme = new NotificationScheme()
            {
                NotificationName = notificationName,
                EntityTypeName = entityIdentifier?.Type.FullName,
                EntityTypeAssemblyQualifiedName = entityIdentifier?.Type.AssemblyQualifiedName,
                EntityId = entityIdentifier?.Id.ToJsonString(),
                Severity = severity,
                UserIds = (userIds == null || userIds.Length <= 0) ? null : string.Join(",", userIds),
                ExcludedUserIds = (excludedUserIds == null || excludedUserIds.Length <= 0) ? null : string.Join(",", excludedUserIds),
                Data = data?.ToJsonString(),
                DataTypeName = data?.GetType().AssemblyQualifiedName
            };

            await _notificationRepository.InsertNotificationSchemeAsync(notificationScheme);
            await _notificationRepository.SaveChangesAsync(); //To get Id of the notification

            if (userIds != null && userIds.Length <= MaxUserCountToDirectlyDistributeANotification)
            {
                //We can directly distribute the notification since there are not much receivers
                await _notificationDistributer.DistributeAsync(notificationScheme.Id);
            }
            else
            {
                //We enqueue a background job since distributing may get a long time
                await _backgroundJobManager.EnqueueAsync(new NotificationDistributionJobArgs(notificationScheme.Id));
            }
        }
    }
}
