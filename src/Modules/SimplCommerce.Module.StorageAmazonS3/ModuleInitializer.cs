using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.StorageAmazonS3
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Init(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMediaService, S3MediaService>();
        }
    }
}
