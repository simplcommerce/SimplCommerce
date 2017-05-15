using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.Module.Core.Extensions
{
    public class EFConfigProvider : ConfigurationProvider
    {
        private Action<DbContextOptionsBuilder> OptionsAction { get; }

        public EFConfigProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<EFConfigurationDbContext>();
            OptionsAction(builder);

            using (var dbContext = new EFConfigurationDbContext(builder.Options))
            {
                Data = dbContext.AppSettings.ToDictionary(c => c.Key, c => c.Value);
            }
        }
    }
}
