using System.Data.Entity;

namespace HvCommerce.Core.Infrastructure.EntityFramework
{
    public class DevelopmentDatabaseInitializer :
        MigrateDatabaseToLatestVersion<HvDbContext, AutomaticMigrationsConfiguration>
    {
    }
}