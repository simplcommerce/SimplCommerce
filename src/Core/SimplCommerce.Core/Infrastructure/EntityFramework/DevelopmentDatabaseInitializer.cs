using System.Data.Entity;

namespace SimplCommerce.Core.Infrastructure.EntityFramework
{
    public class DevelopmentDatabaseInitializer :
        MigrateDatabaseToLatestVersion<HvDbContext, AutomaticMigrationsConfiguration>
    {
    }
}