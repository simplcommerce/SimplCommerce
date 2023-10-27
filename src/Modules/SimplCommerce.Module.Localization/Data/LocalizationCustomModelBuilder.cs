using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Localization.Data
{
    public class LocalizationCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Culture>().ToTable("Localization_Culture");
            modelBuilder.Entity<Resource>().ToTable("Localization_Resource");
            modelBuilder.Entity<LocalizedContentProperty>().ToTable("Localization_LocalizedContentProperty");

            modelBuilder.Entity<Culture>().HasData(
               new Culture("en-US") { Name = "English (US)" }
            );

            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting("Localization.LocalizedConentEnable") { Module = "Localization", IsVisibleInCommonSettingPage = true, Value = "true" });
        }
    }
}
