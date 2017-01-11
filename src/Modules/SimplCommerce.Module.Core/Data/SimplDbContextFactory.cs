using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SimplCommerce.Module.Core.Data
{
    public class SimplDbContextFactory : IDbContextFactory<SimplDbContext>
    {
        public SimplDbContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimplDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SimplCommerce;uid=sa;pwd=sa;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new SimplDbContext(optionsBuilder.Options);
        }
    }
}
