using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Inventory.Models;

namespace SimplCommerce.Module.Inventory.Data
{
    public class InventoryCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>().HasData(new Warehouse(1) { Name = "Default warehouse", AddressId = 1 });
        }
    }
}
