using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SimplCommerce.Module.Core
{
    public static class SettingDefinitionExtensions
    {
        /// <summary>
        /// Can use this method add default user settings in other module.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="defaultSettings"></param>
        public static void AddSettingDefinitionItems(this IApplicationBuilder app, params SettingDefinition[] defaultSettings)
        {
            var settingDefinitionProvider = app.ApplicationServices.GetService<SettingDefinitionProvider>();
            settingDefinitionProvider.AddOrUpdate(defaultSettings);
        }
    }
}
