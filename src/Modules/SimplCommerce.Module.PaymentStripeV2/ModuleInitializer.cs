using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.PaymentStripeV2.Services;

namespace SimplCommerce.Module.PaymentStripeV2
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.RegisterAngularModule("simplAdmin.paymentStripeV2");
            services.AddTransient<IPaymentStripeV2Service, PaymentStripeV2Service>();
            services.AddHostedService<PaymentStripeV2BackgroundService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
