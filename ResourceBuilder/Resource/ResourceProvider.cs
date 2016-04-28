using System;
using System.Collections.Generic;
using System.Linq;
using Shopcuatoi.Core.Domain.Models;

namespace ResourceBuilder.Resource
{
    public abstract class ResourceProvider : IResourceProvider
    {
        // Cache list of resources
        private static Dictionary<string, ResourceEntry> resourceEntries;

        private static readonly object lockResources = new object();

        protected ResourceProvider()
        {
            Cache = true; // By default, enable caching for performance
        }

        protected bool Cache { get; set; } // Cache resources ?

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        public object GetResource(string name, string culture)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Resource name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Culture name cannot be null or empty.");

            // normalize
            culture = culture.ToLowerInvariant();

            if (Cache && resourceEntries == null)
            {
                // Fetch all resources

                lock (lockResources)
                {

                    if (resourceEntries == null)
                    {
                        resourceEntries = ReadResources().ToDictionary(r => $"{r.Culture.ToLowerInvariant()}.{r.Name}");
                    }
                }
            }

            if (Cache)
            {
                return resourceEntries[$"{culture}.{name}"].Value;
            }

            return ReadResource(name, culture).Value;

        }

        /// <summary>
        /// Returns all resources for all cultures. (Needed for caching)
        /// </summary>
        /// <returns>A list of resources</returns>
        protected abstract IList<ResourceEntry> ReadResources();


        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        protected abstract ResourceEntry ReadResource(string name, string culture);

    }
}
