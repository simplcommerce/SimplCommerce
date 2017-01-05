using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.Module.Core.Extensions
{
    public class EFConfigProvider : ConfigurationProvider
    {
        public EFConfigProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        Action<DbContextOptionsBuilder> OptionsAction { get; }

        // Load config data from EF DB.
        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<EFConfigurationDbContext>();
            OptionsAction(builder);

            using (var dbContext = new EFConfigurationDbContext(builder.Options))
            {
                try
                {
                    Data = dbContext.AppSettings.ToDictionary(c => c.Key, c => c.Value);
                }
                catch (Exception ex)
                {
                    // TODO:This might fail when run EF CLI because the table was not there. Need some workaround
                }
            }
        }
    }
}
