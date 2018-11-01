using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.ProductRecentlyViewed.Data;
using SimplCommerce.Module.ProductRecentlyViewed.Events;

namespace SimplCommerce.Module.ProductRecentlyViewed
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRecentlyViewedProductRepository, RecentlyViewedProductRepository>();
            services.AddTransient<INotificationHandler<EntityViewed>, EntityViewedHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
