using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Localization.Events;
using SimplCommerce.Module.Localization.Services;

namespace SimplCommerce.Module.Localization
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INotificationHandler<UserSignedIn>, UserSignedInHandler>();
            services.AddTransient<IContentLocalizationService, ContentLocalizationService>();

            GlobalConfiguration.RegisterAngularModule("simplAdmin.localization");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
