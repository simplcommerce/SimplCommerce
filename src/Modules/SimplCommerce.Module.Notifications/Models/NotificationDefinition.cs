using System;
using System.Collections.Generic;
using SimplCommerce.Infrastructure.Extensions;

namespace SimplCommerce.Module.Notifications.Models
{
    /// <summary>
    /// Definition for a notification.
    /// </summary>
    public class NotificationDefinition
    {
        /// <summary>
        /// Unique name of the notification.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Related entity type with this notification (optional).
        /// </summary>
        public Type EntityType { get; private set; }

        /// <summary>
        /// Display name of the notification.
        /// Optional.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Description for the notification.
        /// Optional.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets/sets arbitrary objects related to this object.
        /// Gets null if given key does not exists.
        /// This is a shortcut for <see cref="Attributes"/> dictionary.
        /// </summary>
        /// <param name="key">Key</param>
        public object this[string key]
        {
            get => Attributes.GetOrDefault(key);
            set => Attributes[key] = value;
        }

        /// <summary>
        /// Arbitrary objects related to this object.
        /// These objects must be serializable.
        /// </summary>
        public IDictionary<string, object> Attributes { get; private set; }

        /// <summary>
        /// Roles Permission Dependency
        /// </summary>
        public string[] ForRoles { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationDefinition"/> class.
        /// </summary>
        /// <param name="name">Unique name of the notification.</param>
        /// <param name="entityType">Related entity type with this notification (optional).</param>
        /// <param name="displayName">Display name of the notification.</param>
        /// <param name="description">Description for the notification</param>
        /// <param name="forRoles"></param>
        public NotificationDefinition(string name, Type entityType = null, string displayName = null, string description = null, string[] forRoles = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "name can not be null, empty or whitespace!");
            }

            Name = name;
            EntityType = entityType;
            DisplayName = displayName;
            Description = description;
            ForRoles = forRoles;
            Attributes = new Dictionary<string, object>();
        }
    }
}
