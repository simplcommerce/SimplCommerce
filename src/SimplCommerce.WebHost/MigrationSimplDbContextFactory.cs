using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Module.Core.Data;

namespace SimplCommerce.WebHost
{
    public class MigrationSimplDbContextFactory : IDbContextFactory<SimplDbContext>
    {
        public SimplDbContext Create(string[] args) =>
            Program.BuildWebHost(args).Services.GetRequiredService<SimplDbContext>();
    }
}
