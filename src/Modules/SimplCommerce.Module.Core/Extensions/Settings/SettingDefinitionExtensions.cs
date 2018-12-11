using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SimplCommerce.Module.Core
{
    public static class SettingDefinitionExtensions
    {
        public static void AddSettingDefinitionItems(this IApplicationBuilder app, params SettingDefinition[] defaultSettings)
        {
            var settingDefinitionProvider = app.ApplicationServices.GetService<SettingDefinitionProvider>();
            settingDefinitionProvider.AddOrUpdate(defaultSettings);
        }
    }
}
