using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications
{
    /// <summary>
    /// Pre-defined notifications.
    /// </summary>
    public static class NotificationDefinitions
    {
        public static class Names
        {
            public const string NewUserRegistered = "NewUserRegistered";
        }

        public static NotificationDefinition[] DefaultItems()
        {
            var notifications = new[]
            {
                new NotificationDefinition(Names.NewUserRegistered, forRoles:new []{"admin"})
            };

            return notifications;
        }
    }
}
