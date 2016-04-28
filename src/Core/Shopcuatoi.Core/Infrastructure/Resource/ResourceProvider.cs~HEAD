using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopcuatoi.Core.Infrastructure.Resource
{
    public abstract class ResourceProvider : IResourceProvider
    {
        // Cache list of resources
        private static Dictionary<string, Domain.Models.Resource> resources;

        private static readonly object lockResources = new object();

        protected ResourceProvider()
        {
            Cache = true; // By default, enable caching for performance
        }

        protected bool Cache { get; set; } // Cache resources ?

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resource name (ie key)</param>
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

            if (Cache && resources == null)
            {
                // Fetch all resources

                lock (lockResources)
                {

                    if (resources == null)
                    {
                        resources = ReadResources().ToDictionary(r => $"{r.Culture.ToLowerInvariant()}.{r.Key}");
                    }
                }
            }

            if (Cache)
            {
                return resources[$"{culture}.{name}"].Value;
            }

            return ReadResource(name, culture).Value;

        }

        /// <summary>
        /// Returns all resources for all cultures. (Needed for caching)
        /// </summary>
        /// <returns>A list of resources</returns>
        protected abstract IList<Domain.Models.Resource> ReadResources();

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resource name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        protected abstract Domain.Models.Resource ReadResource(string name, string culture);


        /// <summary>
        /// Create resources from sql file.
        /// </summary>
        public abstract void CreateResources(string filePath);

    }
}
