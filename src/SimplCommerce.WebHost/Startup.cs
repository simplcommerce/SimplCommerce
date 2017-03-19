using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Serilog;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Localization;
using SimplCommerce.WebHost.Extensions;
using Microsoft.EntityFrameworkCore;

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

            builder.AddEnvironmentVariables();
            var connectionStringConfig = builder.Build();

            builder.AddEntityFrameworkConfig(options =>
                    options.UseSqlServer(connectionStringConfig.GetConnectionString("DefaultConnection"))
           );

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
              .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "logs\\log-{Date}.log"))
              .CreateLogger();
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
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddScoped<SignInManager<User>, SimplSignInManager<User>>();
            services.AddCloudscribePagination();

            services.Configure<RazorViewEngineOptions>(
                options => { options.ViewLocationExpanders.Add(new ModuleViewLocationExpander()); });

            services.AddCustomizedMvc(GlobalConfiguration.Modules);

            return services.Build(Configuration, _hostingEnvironment);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.WithFilter(new FilterLoggerSettings
                {
                    { "Microsoft", LogLevel.Warning },
                    { "System", LogLevel.Warning },
                    { "SimplCommerce", LogLevel.Debug }
                })
                .AddConsole()
                .AddSerilog();

                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                loggerFactory.WithFilter(new FilterLoggerSettings
                {
                    { "Microsoft", LogLevel.Warning },
                    { "System", LogLevel.Warning },
                    { "SimplCommerce", LogLevel.Error }
                })
                .AddSerilog();

                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePagesWithReExecute("/Home/ErrorWithCode/{0}");

            app.UseCustomizedRequestLocalization();
            app.UseCustomizedStaticFiles(env);
            app.UseCustomizedIdentity();
            app.UseCustomizedMvc();
        }
    }
}