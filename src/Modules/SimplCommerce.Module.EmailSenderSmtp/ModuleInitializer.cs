using SimplCommerce.Infrastructure;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.EmailSenderSmtp
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEmailSender, EmailSender>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
