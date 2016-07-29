using Microsoft.Extensions.DependencyInjection;

namespace SimplCommerce.Infrastructure
{
    public interface IModuleInitializer
    {
        void Init(IServiceCollection serviceCollection);
    }
}
