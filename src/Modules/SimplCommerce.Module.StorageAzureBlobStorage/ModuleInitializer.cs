using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.StorageAzureBlobStorage
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Init(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMediaService, AzureBlobMediaService>();
        }
    }
}
