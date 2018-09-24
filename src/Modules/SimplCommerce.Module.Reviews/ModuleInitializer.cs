using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Reviews.Data;

namespace SimplCommerce.Module.Reviews
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IReplyRepository, ReplyRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
