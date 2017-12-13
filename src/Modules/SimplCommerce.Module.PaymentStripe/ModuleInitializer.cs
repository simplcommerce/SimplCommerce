using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using SimplCommerce.Infrastructure;
using Stripe;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.Module.PaymentStripe
{
    public class ModuleInitializer : IModuleInitializer
    {
        private readonly IConfiguration _configuration;

        public ModuleInitializer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            StripeConfiguration.SetApiKey(_configuration["Stripe:SecretKey"]);
        }
    }
}
