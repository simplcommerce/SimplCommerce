using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Core
{
    public class SettingDefinition
    {
        /// <summary>
        /// Unique name of the setting.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Display name of the setting.
        /// This can be used to show setting to the user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A brief description for this setting.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Default value of the setting.
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Can clients see this setting and it's value.
        /// It maybe dangerous for some settings to be visible to clients (such as email server password).
        /// Default: false.
        /// </summary>
        public bool IsVisibleToClients { get; set; }

        /// <summary>
        /// Can be used to store some custom objects related to this setting.
        /// </summary>
        public Dictionary<string, object> ExtraProperties { get; set; }

        /// <summary>
        /// Creates a new <see cref="SettingDefinition"/> object.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="defaultValue">Default value of the setting</param>
        /// <param name="displayName">Display name of the permission</param>
        /// <param name="description">A brief description for this setting</param>
        /// <param name="isVisibleToClients">Can clients see this setting and it's value. Default: false</param>
        public SettingDefinition(
            string name,
            string defaultValue,
            string displayName = null,
            string description = null,
            bool isVisibleToClients = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            DefaultValue = defaultValue;
            DisplayName = displayName;
            Description = description;
            IsVisibleToClients = isVisibleToClients;
            ExtraProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Can be used to store some custom objects related to this setting.
        /// </summary>
        /// <param name="extraProperties"></param>
        public virtual void SetExtraProperties(Dictionary<string, object> extraProperties)
        {
            if (extraProperties != null)
            {
                ExtraProperties = extraProperties;
            }
        }
    }
}

