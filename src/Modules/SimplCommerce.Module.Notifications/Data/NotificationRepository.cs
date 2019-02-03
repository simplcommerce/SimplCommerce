using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Data
{
    /// <summary>
    /// Implements <see cref="INotificationStore"/> using repositories.
    /// </summary>
    public class NotificationRepository : INotificationRepository
    {
        protected DbContext Context { get; }

        private readonly IRepository<NotificationScheme> _notificationSchemeRepository;
        private readonly IRepository<NotificationDetail> _notificationDetailRepository;
        private readonly IRepositoryWithTypedId<UserNotification, Guid> _userNotificationRepository;
        private readonly IRepository<NotificationSubscription> _notificationSubscriptionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRepository"/> class.
        /// </summary>
        public NotificationRepository(SimplDbContext context,
            IRepository<NotificationScheme> notificationRepository,
            IRepository<NotificationDetail> tenantNotificationRepository,
            IRepositoryWithTypedId<UserNotification, Guid> userNotificationRepository,
            IRepository<NotificationSubscription> notificationSubscriptionRepository)
        {
            Context = context;

            _notificationSchemeRepository = notificationRepository;
            _notificationDetailRepository = tenantNotificationRepository;
            _userNotificationRepository = userNotificationRepository;
            _notificationSubscriptionRepository = notificationSubscriptionRepository;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public virtual Task InsertSubscriptionAsync(NotificationSubscription subscription)
        {
            _notificationSubscriptionRepository.Add(subscription);
            return Task.CompletedTask;
        }

        public virtual Task DeleteSubscriptionAsync(long userId, string notificationName, string entityTypeName, string entityId)
        {
            var notificationSubscription = _notificationSubscriptionRepository.Query().FirstOrDefault(s =>
                s.UserId == userId &&
                s.NotificationName == notificationName &&
                s.EntityTypeName == entityTypeName &&
                s.EntityId == entityId);

            if (notificationSubscription != null)
            {
                notificationSubscription.IsDeleted = true;
                //_notificationSubscriptionRepository.Remove(notificationSubscription);
            }

            return Task.CompletedTask;
        }

        public virtual Task InsertNotificationSchemeAsync(NotificationScheme notification)
        {
            _notificationSchemeRepository.Add(notification);
            return Task.CompletedTask;
        }

        public virtual async Task<NotificationScheme> GetNotificationSchemeOrNullAsync(long notificationId)
        {
            return await _notificationSchemeRepository.Query().FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == notificationId);
        }

        public virtual Task InsertUserNotificationAsync(UserNotification userNotification)
        {
            _userNotificationRepository.Add(userNotification);
            return Task.CompletedTask;
        }

        public virtual async Task<List<NotificationSubscription>> GetSubscriptionsAsync(string notificationName, string entityTypeName, string entityId)
        {
            return await _notificationSubscriptionRepository.Query().Where(s =>
                !s.IsDeleted &&
                s.NotificationName == notificationName &&
                s.EntityTypeName == entityTypeName &&
                s.EntityId == entityId
                ).ToListAsync();
        }

        public virtual async Task<List<NotificationSubscription>> GetSubscriptionsAsync(long userId)
        {
            return await _notificationSubscriptionRepository.Query().Where(s => !s.IsDeleted && s.UserId == userId).ToListAsync();
        }

        public virtual async Task<bool> IsSubscribedAsync(long userId, string notificationName, string entityTypeName, string entityId)
        {
            return await _notificationSubscriptionRepository.Query().AnyAsync(s =>
                !s.IsDeleted &&
                s.UserId == userId &&
                s.NotificationName == notificationName &&
                s.EntityTypeName == entityTypeName &&
                s.EntityId == entityId
                );
        }

        public virtual async Task UpdateUserNotificationStateAsync(Guid userNotificationId, UserNotificationState state)
        {
            var userNotification = await _userNotificationRepository.Query().FirstOrDefaultAsync(s => s.Id == userNotificationId);
            if (userNotification == null)
            {
                return;
            }

            userNotification.State = state;
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAllUserNotificationStatesAsync(long userId, UserNotificationState state)
        {
            var userNotifications = await _userNotificationRepository.Query().Where(s => s.UserId == userId).ToListAsync();

            foreach (var userNotification in userNotifications)
            {
                userNotification.State = state;
            }
            await SaveChangesAsync();
        }

        public virtual async Task DeleteUserNotificationAsync(Guid userNotificationId)
        {
            var userNotification = await _userNotificationRepository.Query().FirstOrDefaultAsync(s => s.Id == userNotificationId);
            if (userNotification == null)
            {
                return;
            }

            userNotification.IsDeleted = true;
            //_userNotificationRepository.Remove(userNotification);
        }

        public virtual Task DeleteAllUserNotificationsAsync(long userId)
        {
            var userNotifications = _userNotificationRepository.Query().Where(s => s.UserId == userId);
            foreach (var userNotification in userNotifications)
            {
                userNotification.IsDeleted = true;
                //_userNotificationRepository.Remove(userNotification);
            }
            return Task.CompletedTask;
        }

        public virtual async Task<List<UserNotificationWithNotificationDetail>> GetUserNotificationWithNotificationDetailsAsync(long userId, UserNotificationState? state = null, int skipCount = 0, int maxResultCount = int.MaxValue)
        {
            var query = from userNotification in _userNotificationRepository.Query()
                        join notificationDetail in _notificationDetailRepository.Query() on userNotification.NotificationDetailId equals notificationDetail.Id
                        where !userNotification.IsDeleted && userNotification.UserId == userId && (state == null || userNotification.State == state.Value)
                        orderby notificationDetail.CreatedOn descending
                        select new { userNotification, notificationDetail };

            query = query.Skip(skipCount).Take(maxResultCount);

            var list = await query.ToListAsync();

            return list.Select(a => new UserNotificationWithNotificationDetail(a.userNotification, a.notificationDetail)).ToList();
        }


        public virtual async Task<int> GetUserNotificationCountAsync(long userId, UserNotificationState? state = null)
        {
            return await _userNotificationRepository.Query().CountAsync(s => !s.IsDeleted && s.UserId == userId && (state == null || s.State == state.Value));
        }

        public virtual async Task<UserNotificationWithNotificationDetail> GetUserNotificationWithNotificationDetailOrNullAsync(Guid userNotificationId)
        {
            var query = from userNotification in _userNotificationRepository.Query()
                        join notificationDetail in _notificationDetailRepository.Query() on userNotification.NotificationDetailId equals notificationDetail.Id
                        where !userNotification.IsDeleted && userNotification.Id == userNotificationId
                        select new { userNotification, notificationDetail };

            var item = await query.FirstOrDefaultAsync();
            return item == null ? null : new UserNotificationWithNotificationDetail(item.userNotification, item.notificationDetail);
        }

        public virtual Task InsertNotificationDetailAsync(NotificationDetail tenantNotificationInfo)
        {
            _notificationDetailRepository.Add(tenantNotificationInfo);
            return Task.CompletedTask;
        }

        public virtual Task DeleteNotificationAsync(NotificationScheme notification)
        {
            notification.IsDeleted = true;
            //_notificationSchemeRepository.Remove(notification);
            return Task.CompletedTask;
        }
    }
}
