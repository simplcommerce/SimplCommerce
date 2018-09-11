using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;

namespace SimplCommerce.Module.Localization
{
    public class EfStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IRepository<Resource> _resourceRepository;
        private IList<Resource> _resources;

        public EfStringLocalizerFactory(IRepository<Resource> resourceRepository)
        {
            _resourceRepository = resourceRepository;
            LoadResources();
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new EfStringLocalizer(_resources);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new EfStringLocalizer(_resources);
        }

        private void LoadResources()
        {
            _resources = _resourceRepository.Query().Select(r => new Resource
            {
                Culture = r.Culture,
                Key = r.Key,
                Value = r.Value
            }).ToList();
        }
    }
}