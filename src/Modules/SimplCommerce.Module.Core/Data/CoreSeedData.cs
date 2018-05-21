using System;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Data
{
    public static class CoreSeedData
    {
        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<AppSetting>().HasData(
                new AppSetting("Global.AssetVersion") { Module = "Core", IsVisibleInCommonSettingPage = true, Value = "1.0" },
                new AppSetting("Theme") { Module = "Core", IsVisibleInCommonSettingPage = true, Value = "Generic" }
                );

            builder.Entity<EntityType>().HasData(
                new EntityType("Vendor") { RoutingController = "Vendor", RoutingAction = "VendorDetail", IsMenuable = false }
                );

            builder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "admin", NormalizedName = "ADMIN" },
                new Role { Id = 2, Name = "customer", NormalizedName = "CUSTOMER" },
                new Role { Id = 3, Name = "guest", NormalizedName = "GUEST" },
                new Role { Id = 4, Name = "vendor", NormalizedName = "VENDOR" }
                );

            builder.Entity<User>().HasData(
                new User { IsDeleted = true, Id = 2, UserGuid = Guid.NewGuid(), FullName = "System User", UserName = "system@simplcommerce.com", NormalizedUserName = "SYSTEM@SIMPLCOMMERCE.COM", Email = "system@simplcommerce.com", NormalizedEmail = "SYSTEM@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", SecurityStamp = Guid.NewGuid().ToString() },
                new User { Id = 10, UserGuid = Guid.NewGuid(), FullName = "Shop Admin", UserName = "admin@simplcommerce.com", NormalizedUserName = "ADMIN@SIMPLCOMMERCE.COM", Email = "admin@simplcommerce.com", NormalizedEmail = "ADMIN@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", SecurityStamp = Guid.NewGuid().ToString() }
                );

            builder.Entity<UserRole>().HasData(
                new UserRole { UserId = 10, RoleId = 1 }
                );

            builder.Entity<WidgetZone>().HasData(
                new WidgetZone(1) { Name = "Home Featured" },
                new WidgetZone(2) { Name = "Home Main Content" },
                new WidgetZone(3) { Name = "Home After Main Content" }
                );

            builder.Entity<Country>().HasData(
                new Country("VN") { Code3 = "VNM", Name = "Việt Nam", IsBillingEnabled = true, IsShippingEnabled = true, IsCityEnabled = false, IsZipCodeEnabled = false, IsDistrictEnabled = true },
                new Country("US") { Code3 = "USA", Name = "United States", IsBillingEnabled = true, IsShippingEnabled = true, IsCityEnabled = true, IsZipCodeEnabled = true, IsDistrictEnabled = false }
            );

            builder.Entity<StateOrProvince>().HasData(
                new StateOrProvince(1) { CountryId = "VN", Name = "Hồ Chí Minh", Type = "Thành Phố" },
                new StateOrProvince(2) { CountryId = "US", Name = "Washington", Code = "WA" }
            );

            builder.Entity<District>().HasData(
                new District(1) { Name = "Quận 1", StateOrProvinceId = 1, Type = "Quận" },
                new District(2) { Name = "Quận 2", StateOrProvinceId = 1, Type = "Quận" }
            );

            builder.Entity<Address>().HasData(
                new Address(1) { AddressLine1 = "364 Cong Hoa", ContactName = "Thien Nguyen", CountryId = "VN", StateOrProvinceId = 1 }
            );
        }
    }
}
