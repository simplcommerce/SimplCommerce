using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.News.Services;
using SimplCommerce.Infrastructure;

namespace SimplCommerce.Module.News
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INewsItemService, NewsItemService>();
            services.AddTransient<INewsCategoryService, NewsCategoryService>();

            GlobalConfiguration.RegisterAngularModule("simplAdmin.news");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
