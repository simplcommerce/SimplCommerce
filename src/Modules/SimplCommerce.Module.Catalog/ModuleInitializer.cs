using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Module.Catalog.Data;
using SimplCommerce.Module.Catalog.Events;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Events;

namespace SimplCommerce.Module.Catalog
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductTemplateProductAttributeRepository, ProductTemplateProductAttributeRepository>();
            services.AddTransient<INotificationHandler<ReviewSummaryChanged>, ReviewSummaryChangedHandler>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductPricingService, ProductPricingService>();
            services.AddTransient<IProductService, ProductService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }
    }
}
