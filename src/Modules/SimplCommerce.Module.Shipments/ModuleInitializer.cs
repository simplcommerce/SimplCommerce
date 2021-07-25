using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Orders.Events;
using SimplCommerce.Module.Shipments.Events;
using SimplCommerce.Module.Shipments.Services;

namespace SimplCommerce.Module.Shipments
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INotificationHandler<OrderDetailGot>, OrderDetailGotHandler>();
            services.AddTransient<IShipmentService, ShipmentService>();

            GlobalConfiguration.RegisterAngularModule("simplAdmin.shipment");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
