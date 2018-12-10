using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SimplCommerce.Module.HangfireJobs.Internal;

namespace SimplCommerce.Module.HangfireJobs.Extensions
{
    public static class HangfireConfigureExtensions
    {
        public static void UseHangfire(this IApplicationBuilder app)
        {
            var options = app.ApplicationServices.GetService<IOptions<HangfireConfigureOptions>>()?.Value ?? new HangfireConfigureOptions();

            if (options.EnableServer)
            {
                var _backgroundJobServerOptions = app.ApplicationServices.GetService<IOptions<BackgroundJobServerOptions>>()?.Value;
                app.UseHangfireServer(_backgroundJobServerOptions);
            }

            if (options.Dasbhoard.Enabled)
            {
                ConfigureDashboard(app, options);
            }
        }

        private static void ConfigureDashboard(IApplicationBuilder app, HangfireConfigureOptions options)
        {
            var dashboardOptions = app.ApplicationServices.GetService<IOptions<DashboardOptions>>()?.Value ?? new DashboardOptions();

            if (options.Dasbhoard.EnableAuthorization)
            {
                var dashboardAuthorizationFilter = new HangfireDashboardAuthorizationFilter(options.Dasbhoard.AuthorizationCallback);

                dashboardOptions.Authorization = new[] { dashboardAuthorizationFilter };
            }

            app.UseHangfireDashboard(options: dashboardOptions);
        }
    }
}
