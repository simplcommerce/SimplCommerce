using System.Collections.Generic;
using System.Threading.Tasks;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Services
{
    /// <summary>
    /// Used to manage notification definitions.
    /// </summary>
    public interface INotificationDefinitionManager
    {
        /// <summary>
        /// Adds the specified notification definition.
        /// </summary>
        NotificationDefinitionManager AddOrUpdate(params NotificationDefinition[] notificationDefinitions);

        /// <summary>
        /// Gets a notification definition by name.
        /// Throws exception if there is no notification definition with given name.
        /// </summary>
        NotificationDefinition Get(string name);

        /// <summary>
        /// Gets a notification definition by name.
        /// Returns null if there is no notification definition with given name.
        /// </summary>
        NotificationDefinition GetOrNull(string name);

        /// <summary>
        /// Gets all notification definitions.
        /// </summary>
        IReadOnlyList<NotificationDefinition> GetAll();

        /// <summary>
        /// Checks if given notification (<see cref="name"/>) is available for given user.
        /// </summary>
        Task<bool> IsAvailableAsync(string name, long userId);

        /// <summary>
        /// Gets all available notification definitions for given user.
        /// </summary>
        /// <param name="user">User.</param>
        Task<IReadOnlyList<NotificationDefinition>> GetAllAvailableAsync(long userId);
    }
}
