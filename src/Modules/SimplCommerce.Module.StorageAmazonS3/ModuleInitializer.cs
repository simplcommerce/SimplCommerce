using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.StorageAmazonS3
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStorageService, S3StorageService>();
        }
    }
}
