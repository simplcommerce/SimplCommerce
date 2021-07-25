using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Reviews.Data;

namespace SimplCommerce.Module.Reviews
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IReplyRepository, ReplyRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();

            GlobalConfiguration.RegisterAngularModule("simplAdmin.reviews");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
