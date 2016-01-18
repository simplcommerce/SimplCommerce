using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Core.Infrastructure.EntityFramework
{
    public class DevelopmentDatabaseInitializer : MigrateDatabaseToLatestVersion<HvDbContext, AutomaticMigrationsConfiguration>
    {
    }
}
