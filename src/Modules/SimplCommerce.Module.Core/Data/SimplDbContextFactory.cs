using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SimplCommerce.Module.Core.Data
{
    public class SimplDbContextFactory : IDbContextFactory<SimplDbContext>
    {
        public SimplDbContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimplDbContext>();
            var connection =
                @"Server=(localdb)\MSSQLLocalDB;Database=SimplCommerce;uid=sa;pwd=sa;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("SimplCommerce.WebHost"));
            return new SimplDbContext(optionsBuilder.Options);
        }
    }
}
