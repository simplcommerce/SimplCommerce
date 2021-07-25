using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.ShippingPrices.Services;
using SimplCommerce.Module.ShippingTableRate.Services;

namespace SimplCommerce.Module.ShippingTableRate
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IShippingPriceServiceProvider, TableRateShippingServiceProvider>();

            GlobalConfiguration.RegisterAngularModule("simplAdmin.shipping-tablerate");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
