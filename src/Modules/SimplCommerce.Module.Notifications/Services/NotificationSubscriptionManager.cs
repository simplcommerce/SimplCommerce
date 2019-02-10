using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Module.Notifications.Data;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Services
{
    /// <summary>
    /// Implements <see cref="INotificationSubscriptionManager"/>.
    /// </summary>
    public class NotificationSubscriptionManager : INotificationSubscriptionManager
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationDefinitionManager _notificationDefinitionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationSubscriptionManager"/> class.
        /// </summary>
        public NotificationSubscriptionManager(
            INotificationRepository notificationRepository,
            INotificationDefinitionManager notificationDefinitionManager)
        {
            _notificationRepository = notificationRepository;
            _notificationDefinitionManager = notificationDefinitionManager;
        }

        /// <inheritdoc />
        public async Task SubscribeAsync(long userId, string notificationName, EntityIdentifier entityIdentifier = null)
        {
            if (await IsSubscribedAsync(userId, notificationName, entityIdentifier))
            {
                return;
            }

            await _notificationRepository.InsertSubscriptionAsync(
                new NotificationSubscription(
                    userId,
                    notificationName,
                    entityIdentifier
                    )
                );
            await _notificationRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task SubscribeToAllAvailableNotificationsAsync(long userId)
        {
            var notificationDefinitions = (await _notificationDefinitionManager
                .GetAllAvailableAsync(userId))
                .Where(nd => nd.EntityType == null)
                .ToList();

            foreach (var notificationDefinition in notificationDefinitions)
            {
                await SubscribeAsync(userId, notificationDefinition.Name);
            }
        }

        /// <inheritdoc />
        public async Task UnsubscribeAsync(long user, string notificationName, EntityIdentifier entityIdentifier = null)
        {
            await _notificationRepository.DeleteSubscriptionAsync(
                user,
                notificationName,
                entityIdentifier?.Type.FullName,
                entityIdentifier?.Id.ToJsonString()
                );
            await _notificationRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<List<NotificationSubscriptionDto>> GetSubscriptionsAsync(string notificationName, EntityIdentifier entityIdentifier = null)
        {
            var notificationSubscriptions = await _notificationRepository.GetSubscriptionsAsync(
                notificationName,
                entityIdentifier?.Type.FullName,
                entityIdentifier?.Id.ToJsonString()
                );

            return notificationSubscriptions
                .Select(nsi => nsi.ToNotificationSubscriptionDto())
                .ToList();
        }
        
        /// <inheritdoc />
        public async Task<List<NotificationSubscriptionDto>> GetSubscribedNotificationsAsync(long userId)
        {
            var notificationSubscriptions = await _notificationRepository.GetSubscriptionsAsync(userId);

            return notificationSubscriptions
                .Select(nsi => nsi.ToNotificationSubscriptionDto())
                .ToList();
        }

        /// <inheritdoc />
        public Task<bool> IsSubscribedAsync(long userId, string notificationName, EntityIdentifier entityIdentifier = null)
        {
            return _notificationRepository.IsSubscribedAsync(
                userId,
                notificationName,
                entityIdentifier?.Type.FullName,
                entityIdentifier?.Id.ToJsonString()
                );
        }
    }
}
