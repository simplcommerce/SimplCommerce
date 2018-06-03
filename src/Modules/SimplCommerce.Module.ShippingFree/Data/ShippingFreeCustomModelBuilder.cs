using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.ShippingFree.Data
{
    public class ShippingFreeCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingProvider>().HasData(new ShippingProvider("FreeShip") { Name = "Free Ship", IsEnabled = true, ConfigureUrl = "", ShippingPriceServiceTypeName = "SimplCommerce.Module.ShippingFree.Services.FreeShippingServiceProvider,SimplCommerce.Module.ShippingFree", AdditionalSettings = "{MinimumOrderAmount : 100}", ToAllShippingEnabledCountries = true, ToAllShippingEnabledStatesOrProvinces = true });
        }
    }
}
