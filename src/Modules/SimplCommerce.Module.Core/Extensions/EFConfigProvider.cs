using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Module.Core.Models;

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
                dbContext.Database.Migrate();
                Data = !dbContext.AppSettings.Any()
                    ? CreateAndSaveDefaultValues(dbContext)
                    : dbContext.AppSettings.ToDictionary(c => c.Key, c => c.Value);
            }            
        }
        
        private static IDictionary<string, string> CreateAndSaveDefaultValues(EFConfigurationDbContext dbContext)
        {
            var configValues = new Dictionary<string, string>
                {
                    { "key1", "value_from_ef_1" },
                    { "key2", "value_from_ef_2" }
                };
            dbContext.AppSettings.AddRange(configValues
                .Select(kvp => new AppSetting { Key = kvp.Key, Value = kvp.Value })
                .ToArray());
            dbContext.SaveChanges();
            return configValues;
        }
    }
}