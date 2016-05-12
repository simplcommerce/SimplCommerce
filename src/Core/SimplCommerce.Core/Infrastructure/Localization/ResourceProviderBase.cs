using System;
using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.Infrastructure.Localization
{
    public abstract class ResourceProviderBase
    {
        private static Dictionary<string, StringResource> resources;
        private static readonly object LockResources = new object();

        protected ResourceProviderBase()
        {
            Cache = true;
        }

        protected bool Cache { get; set; }

        /// <summary>
        ///     Returns a single resource for a specific culture
        /// </summary>
        /// <param name="key">Resource key</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        public string GetResource(string key, string culture)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Resource name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Culture name cannot be null or empty.");

            culture = culture.ToLowerInvariant();

            if (Cache && resources == null)
            {
                lock (LockResources)
                {
                    if (resources == null)
                    {
                        resources = ReadResources().ToDictionary(r => $"{r.Culture.ToLowerInvariant()}.{r.Key}");
                    }
                }
            }

            if (Cache)
            {
                return resources[$"{culture}.{key}"].Value;
            }

            return ReadResource(key, culture).Value;
        }

        /// <summary>
        ///     Returns all resources for all cultures. (Needed for caching)
        /// </summary>
        /// <returns>A list of resources</returns>
        public abstract IList<StringResource> ReadResources();

        /// <summary>
        ///     Returns a single resource for a specific culture
        /// </summary>
        /// <param name="key">Resource key</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        protected abstract StringResource ReadResource(string key, string culture);
    }
}