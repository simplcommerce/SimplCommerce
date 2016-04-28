using System;
using System.Linq;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace ResourceBuilder
{
    public class Application : IApplication
    {
        private readonly IRepository<ResourceEntry> resourceEntryRepository;

        public Application(IRepository<ResourceEntry> resourceEntryRepository)
        {
            this.resourceEntryRepository = resourceEntryRepository;
        }

        public void Run()
        {
            var builder = new Resource.ResourceBuilder();

            var resourceEntries = resourceEntryRepository.Query().ToList();

            //string filePath = builder.Create(new DbResourceProvider(resourceEntryRepository), summaryCulture: "en-us");

            //Console.WriteLine("Created file {0}", filePath);

            Console.WriteLine("Done");
        }
    }
}
