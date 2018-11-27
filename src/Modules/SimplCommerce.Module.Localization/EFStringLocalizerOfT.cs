using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;

namespace SimplCommerce.Module.Localization
{
    public class EfStringLocalizer<T> : IStringLocalizer<T>
    {
        private readonly IServiceProvider _serviceProvider;
        private IMemoryCache _resourcesCache;

        public EfStringLocalizer(IServiceProvider serviceProvider, IMemoryCache resourcesCache)
        {
            _serviceProvider = serviceProvider;
            _resourcesCache = resourcesCache;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var culture = CultureInfo.CurrentUICulture.Name;
            var resources = LoadResources(culture);

            return resources.Select(r => new LocalizedString(r.Key, r.Value, true));
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return new EfStringLocalizer(_serviceProvider, _resourcesCache);
        }

        private string GetString(string name)
        {
            var culture = CultureInfo.CurrentUICulture.Name;
            var resources = LoadResources(culture);
            var value = resources.SingleOrDefault(r => r.Key == name)?.Value;

            return value;
        }

        private IList<Resource> LoadResources(string culture)
        {
            if (!_resourcesCache.TryGetValue(culture, out IList<Resource> resources))
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var resourceRepository = scope.ServiceProvider.GetRequiredService<IRepository<Resource>>();
                    resources = resourceRepository.Query().Where(r => r.Culture.Id == culture).ToList();
                }
                _resourcesCache.Set(culture, resources);
            }

            return resources;
        }
    }
}