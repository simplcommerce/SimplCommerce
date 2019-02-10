using SimplCommerce.Module.Core;

namespace SimplCommerce.Module.Notifications
{
    /// <summary>
    /// Pre-defined settings.
    /// </summary>
    public static class SettingDefinitions
    {
        public static class Names
        {
            /// <summary>
            /// A top-level switch to enable/disable receiving notifications for a user.
            /// "Module.Notifications.ReceiveNotifications".
            /// </summary>
            public const string ReceiveNotifications = "NotificationSettings.ReceiveNotifications";
        }

        public static SettingDefinition[] DefaultItems()
        {
            var settings = new[]
            {
                new SettingDefinition(Names.ReceiveNotifications, "true", isVisibleToClients: true),
            };

            return settings;
        }
    }
}
