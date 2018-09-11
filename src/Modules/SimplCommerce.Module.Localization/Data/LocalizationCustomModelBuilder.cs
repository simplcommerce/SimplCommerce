using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;

namespace SimplCommerce.Module.Localization.Data
{
    public class LocalizationCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Culture>().HasData(
               new Culture("en-US") { Name = "English (US)", IsDefault = true }
            );
            modelBuilder.Entity<Culture>().Property(c => c.IsDefault).HasDefaultValue(false);
            modelBuilder.Entity<Culture>().ToTable("Localization_Culture");
            modelBuilder.Entity<Resource>().ToTable("Localization_Resource");
        }
    }
}
