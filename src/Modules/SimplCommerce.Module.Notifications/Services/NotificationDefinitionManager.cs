using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Services
{
    /// <summary>
    /// Implements <see cref="INotificationDefinitionManager"/>.
    /// </summary>
    public class NotificationDefinitionManager : INotificationDefinitionManager
    {
        protected IServiceScopeFactory ServiceScopeFactory { get; }

        private readonly IDictionary<string, NotificationDefinition> _notificationDefinitions;

        public NotificationDefinitionManager(IServiceScopeFactory serviceScopeFactory)
        {
            ServiceScopeFactory = serviceScopeFactory;
            _notificationDefinitions = new Dictionary<string, NotificationDefinition>();
        }

        /// <inheritdoc />
        public NotificationDefinitionManager AddOrUpdate(params NotificationDefinition[] definitions)
        {
            if (definitions != null && definitions.Length > 0)
            {
                foreach (var definition in definitions)
                {
                    _notificationDefinitions[definition.Name] = definition;
                }
            }
            return this;
        }

        /// <inheritdoc />
        public NotificationDefinition Get(string name)
        {
            var definition = GetOrNull(name);
            if (definition == null)
            {
                throw new Exception("There is no notification definition with given name: " + name);
            }

            return definition;
        }

        /// <inheritdoc />
        public NotificationDefinition GetOrNull(string name)
        {
            return _notificationDefinitions.GetOrDefault(name);
        }

        /// <inheritdoc />
        public IReadOnlyList<NotificationDefinition> GetAll()
        {
            return _notificationDefinitions.Values.ToImmutableList();
        }

        /// <inheritdoc />
        public async Task<bool> IsAvailableAsync(string name, long userId)
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var _userRepository = scope.ServiceProvider.GetRequiredService<IRepository<User>>();
                var notificationDefinition = GetOrNull(name);

                if (notificationDefinition?.ForRoles != null)
                {
                    var user = await _userRepository.Query().Include(x => x.Roles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Id == userId);
                    if (user == null)
                    {
                        return false;
                    }
                    var userRoles = user.Roles.Select(r => r.Role.Name).ToArray();
                    return userRoles.Intersect(notificationDefinition.ForRoles).Any();
                }

                return true;
            }
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<NotificationDefinition>> GetAllAvailableAsync(long userId)
        {
            var availableDefinitions = new List<NotificationDefinition>();

            foreach (var notificationDefinition in GetAll())
            {
                if (!await IsAvailableAsync(notificationDefinition.Name, userId))
                {
                    continue;
                }
                availableDefinitions.Add(notificationDefinition);
            }

            return availableDefinitions.ToImmutableList();
        }
    }
}
