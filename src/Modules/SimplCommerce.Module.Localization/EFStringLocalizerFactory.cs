using System;
using Microsoft.Extensions.Localization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Localization.Models;

namespace SimplCommerce.Module.Localization
{
    public class EFStringLocalizerFactory : IStringLocalizerFactory
    {
        private IRepository<Resource> _resourceRepository;

        public EFStringLocalizerFactory(IRepository<Resource> resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new EFStringLocalizer(_resourceRepository);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new EFStringLocalizer(_resourceRepository);
        }
    }
}
