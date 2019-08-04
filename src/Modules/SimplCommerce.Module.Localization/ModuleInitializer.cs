using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Localization.Events;
using SimplCommerce.Module.Localization.Services;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Infrastructure;

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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
