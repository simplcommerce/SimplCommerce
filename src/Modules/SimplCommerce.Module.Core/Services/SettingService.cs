using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public class SettingService : ISettingService
    {
        private readonly UserManager<User> _userManager;
        private readonly SettingDefinitionProvider _settingDefinitionProvider;
        private readonly IWorkContext _workContext;

        public SettingService(
            UserManager<User> userManager,
            SettingDefinitionProvider settingDefinitionProvider,
            IWorkContext workContext)
        {
            _userManager = userManager;
            _settingDefinitionProvider = settingDefinitionProvider;
            _workContext = workContext;
        }

        /// <inheritdoc />
        public async Task<string> GetSettingValueAsync(string name)
        {
            var user = await _workContext.GetCurrentUser();
            return await GetSettingValueForUserAsync(user.Id, name);
        }

        /// <inheritdoc />
        public async Task<string> GetSettingValueForUserAsync(long userId, string name)
        {
            var value = await GetCustomSettingValue(userId, name) ?? _settingDefinitionProvider.GetOrNull(name)?.DefaultValue;
            return value;
        }

        /// <inheritdoc />
        public async Task<Dictionary<string, string>> GetAllSettingsAsync()
        {
            var user = await _workContext.GetCurrentUser();
            return await GetAllSettingsForUserAsync(user.Id);
        }

        /// <inheritdoc />
        public async Task<Dictionary<string, string>> GetAllSettingsForUserAsync(long userId)
        {
            var result = new Dictionary<string, string>();

            var defaultSettings = _settingDefinitionProvider.SettingDefinitions;
            var customSettings = await GetAllCustomSettings(userId) ?? new Dictionary<string, string>();
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
        public async Task UpdateSettingForUserAsync(User user, string name, string value)
        {
            SetCustomSettingValueForUser(user, name, value);
            await _userManager.UpdateAsync(user);
        }

        /// <inheritdoc />
        public async Task UpdateSettingAsync(string name, string value)
        {
            var user = await _workContext.GetCurrentUser();
            await UpdateSettingForUserAsync(user, name, value);
        }

        /// <inheritdoc />
        public void SetCustomSettingValueForUser(User user, string name, string value)
        {
            var settings = user.GetData<IDictionary<string, string>>(User.SettingsDataKey) ?? new Dictionary<string, string>();
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

        private async Task<string> GetCustomSettingValue(long userId, string name)
        {
            var settings = await GetAllCustomSettings(userId);
            return settings.GetOrDefault(name);
        }

        private async Task<IDictionary<string, string>> GetAllCustomSettings(long userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user.GetData<IDictionary<string, string>>(User.SettingsDataKey) ?? new Dictionary<string, string>();
        }
    }
}
