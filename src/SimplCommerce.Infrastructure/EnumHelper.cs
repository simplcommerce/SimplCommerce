using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SimplCommerce.Infrastructure
{
    public static class EnumHelper
    {
        public static IDictionary<Enum, string> ToDictionary(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var dics = new Dictionary<Enum, string>();
            var enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                dics.Add(value, GetDisplayName(value));
            }

            return dics;
        }

        public static string GetDisplayName(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var displayName = value.ToString();
            var fieldInfo = value.GetType().GetField(displayName);
            var attributes = (DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes.Length > 0)
            {
                displayName = attributes[0].Description;
            }

            return displayName;
        }
    }
}
