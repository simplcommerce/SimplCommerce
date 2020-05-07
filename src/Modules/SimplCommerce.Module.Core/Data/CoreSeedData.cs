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
                new AppSetting("Global.AssetBundling") { Module = "Core", IsVisibleInCommonSettingPage = true, Value = "false" },
                new AppSetting("Theme") { Module = "Core", IsVisibleInCommonSettingPage = false, Value = "Generic" },
                new AppSetting("Global.DefaultCultureUI") { Module = "Core", IsVisibleInCommonSettingPage = true, Value = "en-US" },
                new AppSetting("Global.DefaultCultureAdminUI") { Module = "Core", IsVisibleInCommonSettingPage = true, Value = "en-US" },
                new AppSetting("Global.CurrencyCulture") { Module = "Core", IsVisibleInCommonSettingPage = true, Value = "en-US" },
                new AppSetting("Global.CurrencyDecimalPlace") { Module = "Core", IsVisibleInCommonSettingPage = true, Value = "2" }
            );

            builder.Entity<EntityType>().HasData(
                new EntityType("Vendor") { AreaName = "Core", RoutingController = "Vendor", RoutingAction = "VendorDetail", IsMenuable = false }
            );

            builder.Entity<Role>().HasData(
                new Role { Id = 1L, ConcurrencyStamp = "4776a1b2-dbe4-4056-82ec-8bed211d1454", Name = "admin", NormalizedName = "ADMIN" },
                new Role { Id = 2L, ConcurrencyStamp = "00d172be-03a0-4856-8b12-26d63fcf4374", Name = "customer", NormalizedName = "CUSTOMER" },
                new Role { Id = 3L, ConcurrencyStamp = "d4754388-8355-4018-b728-218018836817", Name = "guest", NormalizedName = "GUEST" },
                new Role { Id = 4L, ConcurrencyStamp = "71f10604-8c4d-4a7d-ac4a-ffefb11cefeb", Name = "vendor", NormalizedName = "VENDOR" }
            );

            builder.Entity<User>().HasData(
                new User { Id = 2L, AccessFailedCount = 0, ConcurrencyStamp = "101cd6ae-a8ef-4a37-97fd-04ac2dd630e4", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 189, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), Email = "system@simplcommerce.com", EmailConfirmed = false, FullName = "System User", IsDeleted = true, LockoutEnabled = false, NormalizedEmail = "SYSTEM@SIMPLCOMMERCE.COM", NormalizedUserName = "SYSTEM@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", PhoneNumberConfirmed = false, SecurityStamp = "a9565acb-cee6-425f-9833-419a793f5fba", TwoFactorEnabled = false, LatestUpdatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 189, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), UserGuid = new Guid("5f72f83b-7436-4221-869c-1b69b2e23aae"), UserName = "system@simplcommerce.com" },
                new User { Id = 10L, AccessFailedCount = 0, ConcurrencyStamp = "c83afcbc-312c-4589-bad7-8686bd4754c0", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), Email = "admin@simplcommerce.com", EmailConfirmed = false, FullName = "Shop Admin", IsDeleted = false, LockoutEnabled = false, NormalizedEmail = "ADMIN@SIMPLCOMMERCE.COM", NormalizedUserName = "ADMIN@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", PhoneNumberConfirmed = false, SecurityStamp = "d6847450-47f0-4c7a-9fed-0c66234bf61f", TwoFactorEnabled = false, LatestUpdatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), UserGuid = new Guid("ed8210c3-24b0-4823-a744-80078cf12eb4"), UserName = "admin@simplcommerce.com" }
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
