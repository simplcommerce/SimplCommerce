using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Db.MsSql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<SimplDbContext>(options =>
                options.UseSqlServer(connectionString,
                                        x => x.MigrationsAssembly(
                                            typeof(DependencyInjection).Assembly.FullName)
                                        ));
            return services;
        }
    }
}
