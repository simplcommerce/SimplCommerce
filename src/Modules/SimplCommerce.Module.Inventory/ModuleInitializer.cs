using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Inventory.Services;
using SimplCommerce.Infrastructure;
using MediatR;
using SimplCommerce.Module.Catalog.Events;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Inventory.Event;

namespace SimplCommerce.Module.Inventory
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IStockService, StockService>();
            serviceCollection.AddTransient<IStockSubscriptionService, StockSubscriptionService>();
            serviceCollection.AddTransient<INotificationHandler<BackInStock>, BackInStockSendEmailHandler>();


            GlobalConfiguration.RegisterAngularModule("simplAdmin.inventory");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
