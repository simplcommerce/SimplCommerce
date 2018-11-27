using System;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Catalog.Data
{
    public class CatalogCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductLink>()
                .HasOne(x => x.Product)
                .WithMany(p => p.ProductLinks)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductLink>()
                .HasOne(x => x.LinkedProduct)
                .WithMany(p => p.LinkedProductLinks)
                .HasForeignKey(x => x.LinkedProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductTemplateProductAttribute>()
                .HasKey(t => new { t.ProductTemplateId, t.ProductAttributeId });
            modelBuilder.Entity<ProductTemplateProductAttribute>()
                .HasOne(pt => pt.ProductTemplate)
                .WithMany(p => p.ProductAttributes)
                .HasForeignKey(pt => pt.ProductTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductTemplateProductAttribute>()
                .HasOne(pt => pt.ProductAttribute)
                .WithMany(t => t.ProductTemplates)
                .HasForeignKey(pt => pt.ProductAttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting("Catalog.ProductPageSize") { Module = "Catalog", IsVisibleInCommonSettingPage = true, Value = "10" },
                new AppSetting("Catalog.IsProductPriceIncludeTax") { Module = "Catalog", IsVisibleInCommonSettingPage = true, Value = "true" }
            );

            modelBuilder.Entity<EntityType>().HasData(
                new EntityType("Category") { AreaName = "Catalog", RoutingController = "Category", RoutingAction = "CategoryDetail", IsMenuable = true },
                new EntityType("Brand") { AreaName = "Catalog", RoutingController = "Brand", RoutingAction = "BrandDetail", IsMenuable = true },
                new EntityType("Product") { AreaName = "Catalog", RoutingController = "Product", RoutingAction = "ProductDetail", IsMenuable = false }
            );

            modelBuilder.Entity<ProductOption>().HasData(
                new ProductOption(1) { Name = "Color" },
                new ProductOption(2) { Name = "Size" }
            );

            modelBuilder.Entity<Widget>().HasData(
                new Widget("CategoryWidget") { Name = "Category Widget", ViewComponentName = "CategoryWidget", CreateUrl = "widget-category-create", EditUrl = "widget-category-edit", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 160, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                new Widget("ProductWidget") { Name = "Product Widget", ViewComponentName = "ProductWidget", CreateUrl = "widget-product-create", EditUrl = "widget-product-edit", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 163, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                new Widget("SimpleProductWidget") { Name = "Simple Product Widget", ViewComponentName = "SimpleProductWidget", CreateUrl = "widget-simple-product-create", EditUrl = "widget-simple-product-edit", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 163, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
            );
        }
    }
}
