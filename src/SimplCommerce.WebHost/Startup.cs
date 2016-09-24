using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Localization;
using SimplCommerce.WebHost.Extensions;

namespace SimplCommerce.WebHost
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private static readonly IList<ModuleInfo> Modules = new List<ModuleInfo>();

        public Startup(IHostingEnvironment env)
        {
            _hostingEnvironment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;
            services.LoadInstalledModules(Modules, _hostingEnvironment);

            services.AddCustomizedDataStore(Configuration);
            services.AddCustomizedIdentity();

            services.AddSingleton<IStringLocalizerFactory, EfStringLocalizerFactory>();
            services.AddScoped<SignInManager<User>, SimplSignInManager<User>>();

            services.Configure<RazorViewEngineOptions>(
                options => { options.ViewLocationExpanders.Add(new ModuleViewLocationExpander()); });

            services.AddCustomizedMvc(GlobalConfiguration.Modules);
            return services.Build(Configuration, _hostingEnvironment);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomizedRequestLocalization();
            app.UseCustomizedStaticFiles(Modules);
            app.UseCustomizedIdentity();
            app.UseCustomizedMvc();
        }

    }
}