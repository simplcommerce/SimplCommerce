using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Core.Infrastructure.EntityFramework
{
    public class AutomaticMigrationsConfiguration : DbMigrationsConfiguration<HvDbContext>
    {
        public AutomaticMigrationsConfiguration()
        {
            // During the initial development you can turn on this to speed up coding
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HvDbContext context)
        {
            base.Seed(context);
        }
    }
}
