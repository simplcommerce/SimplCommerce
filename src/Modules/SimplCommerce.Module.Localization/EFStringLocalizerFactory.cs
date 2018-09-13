using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;

namespace SimplCommerce.Module.Localization
{
    public class EfStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IRepository<Resource> _resourceRepository;
        private IMemoryCache _resourcesCache;

        public EfStringLocalizerFactory(IRepository<Resource> resourceRepository, IMemoryCache resourcesCache)
        {
            _resourceRepository = resourceRepository;
            _resourcesCache = resourcesCache;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new EfStringLocalizer(_resourceRepository, _resourcesCache);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new EfStringLocalizer(_resourceRepository, _resourcesCache);
        }
    }
}