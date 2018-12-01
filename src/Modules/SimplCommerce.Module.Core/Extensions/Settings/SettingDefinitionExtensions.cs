using System;
using Microsoft.Extensions.DependencyInjection;

namespace SimplCommerce.Module.Core
{
    public static class SettingDefinitionExtensions
    {
        public static void AddSettingDefinitionItems(this IServiceProvider serviceProvider, params SettingDefinition[] definitions)
        {
            var settingDefinitionProvider = serviceProvider.GetService<SettingDefinitionProvider>();
            settingDefinitionProvider.AddOrUpdate(definitions);
        }
    }
}
