using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.ShoppingCart.Events;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.ShoppingCart
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<INotificationHandler<UserSignedIn>, UserSignedInHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
