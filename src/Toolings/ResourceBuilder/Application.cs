using System;
using System.Configuration;
using Shopcuatoi.Core.Infrastructure.EntityFramework;
using Shopcuatoi.Core.Infrastructure.Resource;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace ResourceBuilder
{
    public class Application : IApplication
    {
        private readonly string directoryPath = ConfigurationManager.AppSettings["DirectoryPath"];
        private readonly string resourceDataPath = ConfigurationManager.AppSettings["ResourceDataPath"];

        private readonly IRepository<Shopcuatoi.Core.Domain.Models.Resource> resourceRepository;
        private readonly ISqlRepository sqlRepository;

        public Application(
            IRepository<Shopcuatoi.Core.Domain.Models.Resource> resourceRepository, 
            ISqlRepository sqlRepository)
        {
            this.resourceRepository = resourceRepository;
            this.sqlRepository = sqlRepository;
        }

        public void Run()
        {
            var builder = new ResourceBuilder();

            var provider = new DbResourceProvider(resourceRepository, sqlRepository);

            provider.CreateResources(resourceDataPath);

            var filePath = builder.Create(
                provider,
                summaryCulture: "en-US",
                filePath: directoryPath,
                namespaceName: provider.GetType().Namespace,
                className: "LocalizeString");

            Console.WriteLine("Created file {0}", filePath);


        }
    }
}
