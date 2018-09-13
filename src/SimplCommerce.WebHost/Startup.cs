using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Localization.Extensions;
using SimplCommerce.WebHost.Extensions;

namespace SimplCommerce.WebHost
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;
            services.LoadInstalledModules(_hostingEnvironment.ContentRootPath);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCustomizedDataStore(_configuration);
            services.AddCustomizedIdentity(_configuration);
            services.AddHttpClient();

            services.AddCustomizedLocalization();
            services.AddCloudscribePagination();

            services.Configure<RazorViewEngineOptions>(
                options => { options.ViewLocationExpanders.Add(new ModuleViewLocationExpander()); });

            services.AddCustomizedMvc(GlobalConfiguration.Modules);

            var sp = services.BuildServiceProvider();
            var moduleInitializers = sp.GetServices<IModuleInitializer>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.ConfigureServices(services);
            }

            return services.Build(_configuration, _hostingEnvironment);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseWhen(
                    context => !context.Request.Path.StartsWithSegments("/api"),
                    a => a.UseExceptionHandler("/Home/Error")
                );
            }

            app.UseWhen(
                context => !context.Request.Path.StartsWithSegments("/api"),
                a => a.UseStatusCodePagesWithReExecute("/Home/ErrorWithCode/{0}")
            );

            app.UseCustomizedStaticFiles(env);
            app.UseCookiePolicy();
            app.UseCustomizedIdentity();
            app.UseCustomizedRequestLocalization();
            app.UseCustomizedMvc();

            var moduleInitializers = app.ApplicationServices.GetServices<IModuleInitializer>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.Configure(app, env);
            }
        }
    }
}