using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public class SettingService : ISettingService
    {
        private readonly UserManager<User> _userManager;
        private readonly SettingDefinitionProvider _settingDefinitionProvider;
        private readonly User _currentUser;

        public SettingService(
            UserManager<User> userManager,
            SettingDefinitionProvider settingDefinitionProvider,
            IWorkContext workContext)
        {
            _userManager = userManager;
            _settingDefinitionProvider = settingDefinitionProvider;
            _currentUser = AsyncHelper.RunSync(workContext.GetCurrentUser);
        }

        /// <inheritdoc />
        public Task<string> GetSettingValueAsync(string name)
        {
            return GetSettingValueForUserAsync(_currentUser.Id, name);
        }

        /// <inheritdoc />
        public async Task<string> GetSettingValueForUserAsync(long userId, string name)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var value = GetCustomSettingValue(user, name) ?? _settingDefinitionProvider.GetOrNull(name)?.DefaultValue;
            return value;
        }

        /// <inheritdoc />
        public Task<Dictionary<string, string>> GetAllSettingsAsync()
        {
            return GetAllSettingsForUserAsync(_currentUser.Id);
        }

        /// <inheritdoc />
        public async Task<Dictionary<string, string>> GetAllSettingsForUserAsync(long userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = new Dictionary<string, string>();

            var defaultSettings = _settingDefinitionProvider.SettingDefinitions;
            var customSettings = GetAllCustomSettings(user) ?? new Dictionary<string, string>();
            foreach (var item in defaultSettings.Values)
            {
                result[item.Name] = item.DefaultValue;

                if (customSettings.ContainsKey(item.Name) && customSettings[item.Name] != item.DefaultValue)
                {
                    result[item.Name] = customSettings.GetOrDefault(item.Name);
                }
            }

            return result;
        }

        /// <inheritdoc />
        public async Task UpdateSettingForUserAsync(long userId, string name, string value)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            SetCustomSettingValueForUser(user, name, value);
            await _userManager.UpdateAsync(user);
        }

        /// <inheritdoc />
        public Task UpdateSettingAsync(string name, string value)
        {
            return UpdateSettingForUserAsync(_currentUser.Id, name, value);
        }

        /// <inheritdoc />
        public void SetCustomSettingValueForUser(User user, string name, string value)
        {
            var settings = GetAllCustomSettings(user);
            var defaultSettings = _settingDefinitionProvider.SettingDefinitions;
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (defaultSettings.GetOrDefault(name)?.DefaultValue != value)
                {
                    settings[name] = value;
                }
            }
            else
            {
                settings.Remove(name);
            }
            user.SetData(User.SettingsDataKey, settings);
        }

        private string GetCustomSettingValue(User user, string name)
        {
            var settings = GetAllCustomSettings(user);
            return settings.GetOrDefault(name);
        }

        private IDictionary<string, string> GetAllCustomSettings(User user)
        {
            return user.GetData<IDictionary<string, string>>(User.SettingsDataKey) ?? new Dictionary<string, string>();
        }
    }
}
