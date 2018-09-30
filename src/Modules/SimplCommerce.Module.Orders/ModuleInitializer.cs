using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Orders.Data;
using SimplCommerce.Module.Orders.Events;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Orders.Services;

namespace SimplCommerce.Module.Orders
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderEmailService, OrderEmailService>();
           // services.AddSingleton<IHostedService, OrderCancellationBackgroundService>();
            services.AddTransient<INotificationHandler<OrderChanged>, OrderChangedHandler>();
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
        }
    }
}
