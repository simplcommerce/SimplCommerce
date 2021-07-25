using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
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

            GlobalConfiguration.RegisterAngularModule("simplAdmin.recentlyViewed");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
