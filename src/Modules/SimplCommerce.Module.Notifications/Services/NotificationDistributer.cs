using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Notifications.Data;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Services
{
    /// <summary>
    /// Used to distribute notifications to users.
    /// </summary>
    public class NotificationDistributer : INotificationDistributer
    {
        public ILogger<NotificationDistributer> Logger { get; set; }

        private readonly IRealTimeNotifier _realTimeNotifier;
        private readonly INotificationDefinitionManager _notificationDefinitionManager;
        private readonly INotificationRepository _notificationRepository;
        private readonly ISettingService _settingService;

        public NotificationDistributer(
            INotificationDefinitionManager notificationDefinitionManager,
            INotificationRepository notificationRepository,
            ISettingService settingService,
            IRealTimeNotifier realTimeNotifier)
        {
            Logger = NullLogger<NotificationDistributer>.Instance;
            _realTimeNotifier = realTimeNotifier;

            _notificationDefinitionManager = notificationDefinitionManager;
            _notificationRepository = notificationRepository;
            _settingService = settingService;
        }

        public async Task DistributeAsync(long notificationId)
        {
            var notificationScheme = await _notificationRepository.GetNotificationSchemeOrNullAsync(notificationId);
            if (notificationScheme == null)
            {
                Logger.LogWarning("NotificationDistributionJob can not continue since could not found notification by id: " + notificationId);
                return;
            }

            var userIds = await GetUserIds(notificationScheme);

            var userNotifications = await SaveUserNotifications(userIds, notificationScheme);

            await _notificationRepository.DeleteNotificationAsync(notificationScheme);
            await _notificationRepository.SaveChangesAsync();
            try
            {
                await _realTimeNotifier.SendNotificationsAsync(userNotifications.ToArray());
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex.ToString(), ex);
            }
        }

        protected virtual async Task<long[]> GetUserIds(NotificationScheme notificationScheme)
        {
            List<long> userIds;

            if (!notificationScheme.UserIds.IsNullOrEmpty())
            {
                //Directly get from UserIds and filter out not receive notification users
                userIds = notificationScheme
                    .UserIds
                    .Split(",")
                    .Select(long.Parse)
                    .Where(uid =>
                        AsyncHelper.RunSync(() => _settingService.GetSettingValueForUserAsync(uid, SettingDefinitions.Names.ReceiveNotifications)).ToUpper() == "TRUE")
                    .ToList();
            }
            else
            {
                //Get all subscribed users
                var subscriptions = await _notificationRepository.GetSubscriptionsAsync(
                    notificationScheme.NotificationName,
                    notificationScheme.EntityTypeName,
                    notificationScheme.EntityId
                    );

                //Remove invalid subscriptions
                var invalidSubscriptions = new Dictionary<long, NotificationSubscription>();
                foreach (var subscription in subscriptions)
                {
                    if (!await _notificationDefinitionManager.IsAvailableAsync(notificationScheme.NotificationName, subscription.UserId) ||
                        AsyncHelper.RunSync(() => _settingService.GetSettingValueForUserAsync(subscription.UserId, SettingDefinitions.Names.ReceiveNotifications)).ToUpper() != "TRUE")
                    {
                        invalidSubscriptions[subscription.Id] = subscription;
                    }
                }

                subscriptions.RemoveAll(s => invalidSubscriptions.ContainsKey(s.Id));

                //Get user ids
                userIds = subscriptions.Select(s => s.UserId).ToList();
            }

            if (!notificationScheme.ExcludedUserIds.IsNullOrEmpty())
            {
                //Exclude specified userIds.
                var excludedUserIds = notificationScheme
                    .ExcludedUserIds
                    .Split(",")
                    .Select(long.Parse)
                    .ToList();

                userIds.RemoveAll(uid => excludedUserIds.Any(euid => euid.Equals(uid)));
            }

            return userIds.ToArray();
        }

        protected virtual async Task<List<UserNotificationDto>> SaveUserNotifications(long[] userIds, NotificationScheme notificationScheme)
        {
            var userNotificationDtos = new List<UserNotificationDto>();
            var notificationDetail = new NotificationDetail(notificationScheme);
            await _notificationRepository.InsertNotificationDetailAsync(notificationDetail);
            await _notificationRepository.SaveChangesAsync(); //To get notificationDetail.Id.

            var notificationDetailDto = notificationDetail.ToNotificationDetailDto();

            foreach (var userId in userIds)
            {
                var userNotification = new UserNotification()
                {
                    UserId = userId,
                    NotificationDetailId = notificationDetail.Id
                };

                await _notificationRepository.InsertUserNotificationAsync(userNotification);

                userNotificationDtos.Add(userNotification.ToUserNotificationDto(notificationDetailDto));
            }
            await _notificationRepository.SaveChangesAsync();

            return userNotificationDtos;
        }
    }
}
