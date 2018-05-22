using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.ShippingTableRate.Data
{
    public class ShippingTableRateCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingProvider>().HasData(new ShippingProvider("TableRate") { Name = "Table Rate", IsEnabled = true, ConfigureUrl = "shipping-table-rate-config", ShippingPriceServiceTypeName = "SimplCommerce.Module.ShippingTableRate.Services.TableRateShippingServiceProvider,SimplCommerce.Module.ShippingTableRate", AdditionalSettings = null, ToAllShippingEnabledCountries = true, ToAllShippingEnabledStatesOrProvinces = true });
        }
    }
}
