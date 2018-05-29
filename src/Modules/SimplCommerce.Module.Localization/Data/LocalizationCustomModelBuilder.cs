using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Localization.Models;

namespace SimplCommerce.Module.Localization.Data
{
    public class LocalizationCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Culture>().HasData(
               new Culture("en-US") { Name = "English (US)", IsDefault = true }
            );
        }
    }
}
