using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;

namespace SimplCommerce.Module.Localization
{
    public class EfStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMemoryCache _resourcesCache;

        public EfStringLocalizerFactory(IServiceProvider serviceProvider, IMemoryCache resourcesCache)
        {
            _serviceProvider = serviceProvider;
            _resourcesCache = resourcesCache;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new EfStringLocalizer(_serviceProvider, _resourcesCache);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new EfStringLocalizer(_serviceProvider, _resourcesCache);
        }
    }
}
