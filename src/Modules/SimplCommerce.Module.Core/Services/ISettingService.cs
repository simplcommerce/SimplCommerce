using System.Collections.Generic;
using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    /// <summary>
    /// This is the main interface that must be implemented to be able to load/change values of settings.
    /// </summary>
    public interface ISettingService
    {
        /// <summary>
        /// Gets current value of a setting.
        /// It gets the setting value for current user.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <returns>Current value of the setting</returns>
        Task<string> GetSettingValueAsync(string name);

        /// <summary>
        /// Gets current value of a setting for a user.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="userId">User id</param>
        /// <returns>Current value of the setting for the user</returns>
        Task<string> GetSettingValueForUserAsync(long userId, string name);

        /// <summary>
        /// Gets current values of all settings.
        /// It gets all setting values for current user.
        /// </summary>
        /// <returns>List of setting values</returns>
        Task<Dictionary<string, string>> GetAllSettingsAsync();

        /// <summary>
        /// Gets a list of all settings for a user.
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns>All settings of the user</returns>
        Task<Dictionary<string, string>> GetAllSettingsForUserAsync(long userId);

        /// <summary>
        /// Changes setting for a user.
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        Task UpdateSettingForUserAsync(User user, string name, string value);

        /// <summary>
        /// Changes setting for current user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task UpdateSettingAsync(string name, string value);

        /// <summary>
        /// Sets a custom setting for a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="user">User</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        void SetCustomSettingValueForUser(User user, string name, string value);
    }
}
