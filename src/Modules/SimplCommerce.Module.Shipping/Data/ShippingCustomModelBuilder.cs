using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.Shipping.Data
{
    public class ShippingCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingProvider>().ToTable("Shipping_ShippingProvider");
        }
    }
}
