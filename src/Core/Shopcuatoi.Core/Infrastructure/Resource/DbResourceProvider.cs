using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Shopcuatoi.Core.Infrastructure.EntityFramework;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace Shopcuatoi.Core.Infrastructure.Resource
{
    public class DbResourceProvider : ResourceProvider
    {
        private readonly IRepository<Domain.Models.Resource> resourceRepository;
        private readonly ISqlRepository sqlRepository;

        public DbResourceProvider()
        {
            this.resourceRepository = ServiceLocator.Current.GetInstance<IRepository<Domain.Models.Resource>>();
        }

        public DbResourceProvider(IRepository<Domain.Models.Resource> resourceRepository, ISqlRepository sqlRepository)
        {
            this.resourceRepository = resourceRepository;
            this.sqlRepository = sqlRepository;
        }

        protected override IList<Domain.Models.Resource> ReadResources()
        {
            return resourceRepository.Query().ToList();
        }

        protected override Domain.Models.Resource ReadResource(string name, string culture)
        {
            return resourceRepository.Query().Include(r => r.Culture)
                .FirstOrDefault(r => r.Key.Equals(name) && r.Culture.Equals(culture));
        }

        public override void CreateResources(string filePath)
        {
            var lines = File.ReadLines(filePath);
            var commands = sqlRepository.ParseCommand(lines);
            sqlRepository.RunCommands(commands);
        }
    }
}
