using System.Collections.Generic;
using System.Collections.Immutable;
using SimplCommerce.Infrastructure.Extensions;

namespace SimplCommerce.Module.Core
{
    public class SettingDefinitionProvider
    {
        public SettingDefinitionProvider()
        {
            this.SettingDefinitions = new Dictionary<string, SettingDefinition>();
        }

        public Dictionary<string, SettingDefinition> SettingDefinitions { get; }

        public virtual SettingDefinition GetOrNull(string name)
        {
            return SettingDefinitions.GetOrDefault(name);
        }

        public virtual IReadOnlyList<SettingDefinition> GetAll()
        {
            return SettingDefinitions.Values.ToImmutableList();
        }

        public virtual SettingDefinitionProvider AddOrUpdate(params SettingDefinition[] definitions)
        {
            if (definitions != null && definitions.Length > 0)
            {
                foreach (var definition in definitions)
                {
                    SettingDefinitions[definition.Name] = definition;
                }
            }
            return this;
        }
    }
}
