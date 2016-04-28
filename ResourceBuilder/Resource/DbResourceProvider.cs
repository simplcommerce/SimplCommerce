using System.Collections.Generic;
using System.Linq;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace ResourceBuilder.Resource
{
    public class DbResourceProvider : ResourceProvider
    {
        private readonly IRepository<ResourceEntry> resourceEntryRepository;

        public DbResourceProvider(IRepository<ResourceEntry> resourceEntryRepository)
        {
            this.resourceEntryRepository = resourceEntryRepository;
        }

        protected override IList<ResourceEntry> ReadResources()
        {
            return resourceEntryRepository.Query().ToList();
        }

        protected override ResourceEntry ReadResource(string name, string culture)
        {
            return resourceEntryRepository.Query().FirstOrDefault(r => r.Name.Equals(name) && r.Culture.Equals(culture));
        }
    }
}
