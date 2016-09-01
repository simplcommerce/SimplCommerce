using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.WebHost.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomizedIdentity(this IApplicationBuilder app)
        {
            app.UseIdentity()
                .UseGoogleAuthentication(new GoogleOptions
                {
                    ClientId = "583825788849-8g42lum4trd5g3319go0iqt6pn30gqlq.apps.googleusercontent.com",
                    ClientSecret = "X8xIiuNEUjEYfiEfiNrWOfI4"
                })
                .UseFacebookAuthentication(new FacebookOptions
                {
                    AppId = "1716532045292977",
                    AppSecret = "dfece01ae919b7b8af23f962a1f87f95"
                });
            return app;
        }

        public static IApplicationBuilder UseCustomizedMvc(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.Routes.Add(new UrlSlugRoute(routes.DefaultHandler));

                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
            return app;
        }

        public static IApplicationBuilder UseCustomizedStaticFiles(this IApplicationBuilder app, IList<ModuleInfo> modules)
        {
            app.UseStaticFiles();

            // Serving static file for modules
            foreach (var module in modules)
            {
                var wwwrootDir = new DirectoryInfo(Path.Combine(module.Path, "wwwroot"));
                if (!wwwrootDir.Exists)
                {
                    continue;
                }

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(wwwrootDir.FullName),
                    RequestPath = new PathString("/" + module.ShortName)
                });
            }
            return app;
        }

        public static IApplicationBuilder UseCustomizedRequestLocalization(this IApplicationBuilder app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("vi-VN")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("vi-VN", "vi-VN"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            return app;
        }
    }
}