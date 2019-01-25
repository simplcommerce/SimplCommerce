using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.PaymentBraintree.Services;

namespace SimplCommerce.Module.PaymentBraintree
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBraintreeConfiguration, BraintreeConfiguration>();
        }
    }
}
