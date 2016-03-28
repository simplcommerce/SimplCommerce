using System.Data.Entity;

namespace Shopcuatoi.Core.Infrastructure.EntityFramework
{
    public class DevelopmentDatabaseInitializer :
        MigrateDatabaseToLatestVersion<HvDbContext, AutomaticMigrationsConfiguration>
    {
    }
}