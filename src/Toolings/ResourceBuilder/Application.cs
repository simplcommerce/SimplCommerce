using System;
using System.Configuration;
using System.IO;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Core.Infrastructure.EntityFramework;
using SimplCommerce.Core.Infrastructure.Localization;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace ResourceBuilder
{
    public class Application : IApplication
    {
        private readonly string directoryPath = ConfigurationManager.AppSettings["DirectoryPath"];

        private readonly IRepository<StringResource> resourceRepository;
        private readonly ISqlRepository sqlRepository;

        public Application(
            IRepository<StringResource> resourceRepository,
            ISqlRepository sqlRepository)
        {
            this.resourceRepository = resourceRepository;
            this.sqlRepository = sqlRepository;
        }

        public void Run()
        {
            var builder = new ResourceBuilder();
            var provider = new DbResourceProvider(resourceRepository);

            UpdateStringResourceTable();

            var filePath = Path.Combine(directoryPath, "LocalizedString.cs");

            builder.GenerateStrongTypeResource(
                provider,
                summaryCulture: "en-US",
                filePath: filePath,
                namespaceName: provider.GetType().Namespace,
                className: "LocalizedString");

            Console.WriteLine("Created file {0}", filePath);
        }

        private void UpdateStringResourceTable()
        {
            var sqlResourceDataFile = Path.Combine(directoryPath, "StringResource.sql");

            var lines = File.ReadAllLines(sqlResourceDataFile);

            var commands = sqlRepository.ParseCommand(lines);

            sqlRepository.RunCommands(commands);
        }
    }
}