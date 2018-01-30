using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class SetCascadeToRestrictByDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_Activity_ActivityLog_ActivityType_ActivityTypeId",
                table: "ActivityLog_Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Category_Catalog_Category_ParentId",
                table: "Catalog_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Category_Core_Media_ThumbnailImageId",
                table: "Catalog_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Catalog_Brand_BrandId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_User_CreatedById",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Tax_TaxClass_TaxClassId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_Media_ThumbnailImageId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_User_UpdatedById",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductAttribute_Catalog_ProductAttributeGroup_GroupId",
                table: "Catalog_ProductAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductAttributeValue_Catalog_ProductAttribute_AttributeId",
                table: "Catalog_ProductAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductAttributeValue_Catalog_Product_ProductId",
                table: "Catalog_ProductAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductCategory_Catalog_Category_CategoryId",
                table: "Catalog_ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductCategory_Catalog_Product_ProductId",
                table: "Catalog_ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductMedia_Core_Media_MediaId",
                table: "Catalog_ProductMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductMedia_Catalog_Product_ProductId",
                table: "Catalog_ProductMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_ProductOption_OptionId",
                table: "Catalog_ProductOptionCombination");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionCombination");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionValue_Catalog_ProductOption_OptionId",
                table: "Catalog_ProductOptionValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionValue_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_MenuItem_Core_Entity_EntityId",
                table: "Cms_MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_MenuItem_Cms_Menu_MenuId",
                table: "Cms_MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_MenuItem_Cms_MenuItem_ParentId",
                table: "Cms_MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_Page_Core_User_CreatedById",
                table: "Cms_Page");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_Page_Core_User_UpdatedById",
                table: "Cms_Page");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Contact_Contacts_ContactArea_ContactAreaId",
                table: "Contacts_Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_District_Core_StateOrProvince_StateOrProvinceId",
                table: "Core_District");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Entity_Core_EntityType_EntityTypeId",
                table: "Core_Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_StateOrProvince_Core_Country_CountryId",
                table: "Core_StateOrProvince");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_Vendor_VendorId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserAddress_Core_Address_AddressId",
                table: "Core_UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Core_UserCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserCustomerGroup_Core_User_UserId",
                table: "Core_UserCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserRole_Core_Role_RoleId",
                table: "Core_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserRole_Core_User_UserId",
                table: "Core_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_WidgetInstance_Core_Widget_WidgetId",
                table: "Core_WidgetInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_WidgetInstance_Core_WidgetZone_WidgetZoneId",
                table: "Core_WidgetInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Stock_Catalog_Product_ProductId",
                table: "Inventory_Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_StockHistory_Core_User_CreatedById",
                table: "Inventory_StockHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouse_Core_Address_AddressId",
                table: "Inventory_Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItem_Core_User_CreatedById",
                table: "News_NewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItem_Core_Media_ThumbnailImageId",
                table: "News_NewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItem_Core_User_UpdatedById",
                table: "News_NewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsCategory_CategoryId",
                table: "News_NewsItemCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsItem_NewsItemId",
                table: "News_NewsItemCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Core_User_CreatedById",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_Order_ParentId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistory_Orders_Order_OrderId",
                table: "Orders_OrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_Orders_Order_OrderId",
                table: "Orders_OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_Catalog_Product_ProductId",
                table: "Orders_OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Payment_Orders_Order_OrderId",
                table: "Payments_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCategory_Catalog_Category_CategoryId",
                table: "Pricing_CartRuleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Pricing_CartRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleProduct_Catalog_Product_ProductId",
                table: "Pricing_CartRuleProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleUsage_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleUsage_Core_User_UserId",
                table: "Pricing_CartRuleUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CatalogRule_CatalogRuleId",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                table: "Pricing_Coupon");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CouponUsage_Pricing_Coupon_CouponId",
                table: "Pricing_CouponUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CouponUsage_Core_User_UserId",
                table: "Pricing_CouponUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComparison_ComparingProduct_Catalog_Product_ProductId",
                table: "ProductComparison_ComparingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComparison_ComparingProduct_Core_User_UserId",
                table: "ProductComparison_ComparingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Review_Core_User_UserId",
                table: "Reviews_Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ShipmentItem_Catalog_Product_ProductId",
                table: "Shipments_ShipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ShipmentItem_Shipments_Shipment_ShipmentId",
                table: "Shipments_ShipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_Country_CountryId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_StateOrProvince_StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_UserId",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_CartItem_ShoppingCart_Cart_CartId",
                table: "ShoppingCart_CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_CartItem_Catalog_Product_ProductId",
                table: "ShoppingCart_CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Tax_TaxRate_Core_Country_CountryId",
                table: "Tax_TaxRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Tax_TaxRate_Core_StateOrProvince_StateOrProvinceId",
                table: "Tax_TaxRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Tax_TaxRate_Tax_TaxClass_TaxClassId",
                table: "Tax_TaxRate");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_Activity_ActivityLog_ActivityType_ActivityTypeId",
                table: "ActivityLog_Activity",
                column: "ActivityTypeId",
                principalTable: "ActivityLog_ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Category_Catalog_Category_ParentId",
                table: "Catalog_Category",
                column: "ParentId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Category_Core_Media_ThumbnailImageId",
                table: "Catalog_Category",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Catalog_Brand_BrandId",
                table: "Catalog_Product",
                column: "BrandId",
                principalTable: "Catalog_Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_User_CreatedById",
                table: "Catalog_Product",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Tax_TaxClass_TaxClassId",
                table: "Catalog_Product",
                column: "TaxClassId",
                principalTable: "Tax_TaxClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_Media_ThumbnailImageId",
                table: "Catalog_Product",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_User_UpdatedById",
                table: "Catalog_Product",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductAttribute_Catalog_ProductAttributeGroup_GroupId",
                table: "Catalog_ProductAttribute",
                column: "GroupId",
                principalTable: "Catalog_ProductAttributeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductAttributeValue_Catalog_ProductAttribute_AttributeId",
                table: "Catalog_ProductAttributeValue",
                column: "AttributeId",
                principalTable: "Catalog_ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductAttributeValue_Catalog_Product_ProductId",
                table: "Catalog_ProductAttributeValue",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductCategory_Catalog_Category_CategoryId",
                table: "Catalog_ProductCategory",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductCategory_Catalog_Product_ProductId",
                table: "Catalog_ProductCategory",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductMedia_Core_Media_MediaId",
                table: "Catalog_ProductMedia",
                column: "MediaId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductMedia_Catalog_Product_ProductId",
                table: "Catalog_ProductMedia",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_ProductOption_OptionId",
                table: "Catalog_ProductOptionCombination",
                column: "OptionId",
                principalTable: "Catalog_ProductOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionCombination",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionValue_Catalog_ProductOption_OptionId",
                table: "Catalog_ProductOptionValue",
                column: "OptionId",
                principalTable: "Catalog_ProductOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionValue_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionValue",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_MenuItem_Core_Entity_EntityId",
                table: "Cms_MenuItem",
                column: "EntityId",
                principalTable: "Core_Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_MenuItem_Cms_Menu_MenuId",
                table: "Cms_MenuItem",
                column: "MenuId",
                principalTable: "Cms_Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_MenuItem_Cms_MenuItem_ParentId",
                table: "Cms_MenuItem",
                column: "ParentId",
                principalTable: "Cms_MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_Page_Core_User_CreatedById",
                table: "Cms_Page",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_Page_Core_User_UpdatedById",
                table: "Cms_Page",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Contact_Contacts_ContactArea_ContactAreaId",
                table: "Contacts_Contact",
                column: "ContactAreaId",
                principalTable: "Contacts_ContactArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_District_Core_StateOrProvince_StateOrProvinceId",
                table: "Core_District",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Entity_Core_EntityType_EntityTypeId",
                table: "Core_Entity",
                column: "EntityTypeId",
                principalTable: "Core_EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_StateOrProvince_Core_Country_CountryId",
                table: "Core_StateOrProvince",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_User_Core_Vendor_VendorId",
                table: "Core_User",
                column: "VendorId",
                principalTable: "Core_Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserAddress_Core_Address_AddressId",
                table: "Core_UserAddress",
                column: "AddressId",
                principalTable: "Core_Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Core_UserCustomerGroup",
                column: "CustomerGroupId",
                principalTable: "Core_CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserCustomerGroup_Core_User_UserId",
                table: "Core_UserCustomerGroup",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserRole_Core_Role_RoleId",
                table: "Core_UserRole",
                column: "RoleId",
                principalTable: "Core_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserRole_Core_User_UserId",
                table: "Core_UserRole",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_WidgetInstance_Core_Widget_WidgetId",
                table: "Core_WidgetInstance",
                column: "WidgetId",
                principalTable: "Core_Widget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_WidgetInstance_Core_WidgetZone_WidgetZoneId",
                table: "Core_WidgetInstance",
                column: "WidgetZoneId",
                principalTable: "Core_WidgetZone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Stock_Catalog_Product_ProductId",
                table: "Inventory_Stock",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_StockHistory_Core_User_CreatedById",
                table: "Inventory_StockHistory",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouse_Core_Address_AddressId",
                table: "Inventory_Warehouse",
                column: "AddressId",
                principalTable: "Core_Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource",
                column: "CultureId",
                principalTable: "Localization_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItem_Core_User_CreatedById",
                table: "News_NewsItem",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItem_Core_Media_ThumbnailImageId",
                table: "News_NewsItem",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItem_Core_User_UpdatedById",
                table: "News_NewsItem",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsCategory_CategoryId",
                table: "News_NewsItemCategory",
                column: "CategoryId",
                principalTable: "News_NewsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsItem_NewsItemId",
                table: "News_NewsItemCategory",
                column: "NewsItemId",
                principalTable: "News_NewsItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Core_User_CreatedById",
                table: "Orders_Order",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_Order_ParentId",
                table: "Orders_Order",
                column: "ParentId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHistory_Orders_Order_OrderId",
                table: "Orders_OrderHistory",
                column: "OrderId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_Orders_Order_OrderId",
                table: "Orders_OrderItem",
                column: "OrderId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_Catalog_Product_ProductId",
                table: "Orders_OrderItem",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Payment_Orders_Order_OrderId",
                table: "Payments_Payment",
                column: "OrderId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCategory",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCategory_Catalog_Category_CategoryId",
                table: "Pricing_CartRuleCategory",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCustomerGroup",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Pricing_CartRuleCustomerGroup",
                column: "CustomerGroupId",
                principalTable: "Core_CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleProduct",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleProduct_Catalog_Product_ProductId",
                table: "Pricing_CartRuleProduct",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleUsage_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleUsage",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleUsage_Core_User_UserId",
                table: "Pricing_CartRuleUsage",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CatalogRule_CatalogRuleId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CatalogRuleId",
                principalTable: "Pricing_CatalogRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CustomerGroupId",
                principalTable: "Core_CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                table: "Pricing_Coupon",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CouponUsage_Pricing_Coupon_CouponId",
                table: "Pricing_CouponUsage",
                column: "CouponId",
                principalTable: "Pricing_Coupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CouponUsage_Core_User_UserId",
                table: "Pricing_CouponUsage",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComparison_ComparingProduct_Catalog_Product_ProductId",
                table: "ProductComparison_ComparingProduct",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComparison_ComparingProduct_Core_User_UserId",
                table: "ProductComparison_ComparingProduct",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Review_Core_User_UserId",
                table: "Reviews_Review",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ShipmentItem_Catalog_Product_ProductId",
                table: "Shipments_ShipmentItem",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ShipmentItem_Shipments_Shipment_ShipmentId",
                table: "Shipments_ShipmentItem",
                column: "ShipmentId",
                principalTable: "Shipments_Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_Country_CountryId",
                table: "ShippingTableRate_PriceAndDestination",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_StateOrProvince_StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_UserId",
                table: "ShoppingCart_Cart",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_CartItem_ShoppingCart_Cart_CartId",
                table: "ShoppingCart_CartItem",
                column: "CartId",
                principalTable: "ShoppingCart_Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_CartItem_Catalog_Product_ProductId",
                table: "ShoppingCart_CartItem",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tax_TaxRate_Core_Country_CountryId",
                table: "Tax_TaxRate",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tax_TaxRate_Core_StateOrProvince_StateOrProvinceId",
                table: "Tax_TaxRate",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tax_TaxRate_Tax_TaxClass_TaxClassId",
                table: "Tax_TaxRate",
                column: "TaxClassId",
                principalTable: "Tax_TaxClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_Activity_ActivityLog_ActivityType_ActivityTypeId",
                table: "ActivityLog_Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Category_Catalog_Category_ParentId",
                table: "Catalog_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Category_Core_Media_ThumbnailImageId",
                table: "Catalog_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Catalog_Brand_BrandId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_User_CreatedById",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Tax_TaxClass_TaxClassId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_Media_ThumbnailImageId",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_User_UpdatedById",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductAttribute_Catalog_ProductAttributeGroup_GroupId",
                table: "Catalog_ProductAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductAttributeValue_Catalog_ProductAttribute_AttributeId",
                table: "Catalog_ProductAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductAttributeValue_Catalog_Product_ProductId",
                table: "Catalog_ProductAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductCategory_Catalog_Category_CategoryId",
                table: "Catalog_ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductCategory_Catalog_Product_ProductId",
                table: "Catalog_ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductMedia_Core_Media_MediaId",
                table: "Catalog_ProductMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductMedia_Catalog_Product_ProductId",
                table: "Catalog_ProductMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_ProductOption_OptionId",
                table: "Catalog_ProductOptionCombination");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionCombination");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionValue_Catalog_ProductOption_OptionId",
                table: "Catalog_ProductOptionValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionValue_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_MenuItem_Core_Entity_EntityId",
                table: "Cms_MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_MenuItem_Cms_Menu_MenuId",
                table: "Cms_MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_MenuItem_Cms_MenuItem_ParentId",
                table: "Cms_MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_Page_Core_User_CreatedById",
                table: "Cms_Page");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_Page_Core_User_UpdatedById",
                table: "Cms_Page");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Contact_Contacts_ContactArea_ContactAreaId",
                table: "Contacts_Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_District_Core_StateOrProvince_StateOrProvinceId",
                table: "Core_District");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Entity_Core_EntityType_EntityTypeId",
                table: "Core_Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_StateOrProvince_Core_Country_CountryId",
                table: "Core_StateOrProvince");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_Vendor_VendorId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserAddress_Core_Address_AddressId",
                table: "Core_UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Core_UserCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserCustomerGroup_Core_User_UserId",
                table: "Core_UserCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserRole_Core_Role_RoleId",
                table: "Core_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserRole_Core_User_UserId",
                table: "Core_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_WidgetInstance_Core_Widget_WidgetId",
                table: "Core_WidgetInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_WidgetInstance_Core_WidgetZone_WidgetZoneId",
                table: "Core_WidgetInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Stock_Catalog_Product_ProductId",
                table: "Inventory_Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_StockHistory_Core_User_CreatedById",
                table: "Inventory_StockHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouse_Core_Address_AddressId",
                table: "Inventory_Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItem_Core_User_CreatedById",
                table: "News_NewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItem_Core_Media_ThumbnailImageId",
                table: "News_NewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItem_Core_User_UpdatedById",
                table: "News_NewsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsCategory_CategoryId",
                table: "News_NewsItemCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsItem_NewsItemId",
                table: "News_NewsItemCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Core_User_CreatedById",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_Order_ParentId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistory_Orders_Order_OrderId",
                table: "Orders_OrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_Orders_Order_OrderId",
                table: "Orders_OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_Catalog_Product_ProductId",
                table: "Orders_OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Payment_Orders_Order_OrderId",
                table: "Payments_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCategory_Catalog_Category_CategoryId",
                table: "Pricing_CartRuleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Pricing_CartRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleProduct_Catalog_Product_ProductId",
                table: "Pricing_CartRuleProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleUsage_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleUsage_Core_User_UserId",
                table: "Pricing_CartRuleUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CatalogRule_CatalogRuleId",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                table: "Pricing_Coupon");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CouponUsage_Pricing_Coupon_CouponId",
                table: "Pricing_CouponUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CouponUsage_Core_User_UserId",
                table: "Pricing_CouponUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComparison_ComparingProduct_Catalog_Product_ProductId",
                table: "ProductComparison_ComparingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComparison_ComparingProduct_Core_User_UserId",
                table: "ProductComparison_ComparingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Review_Core_User_UserId",
                table: "Reviews_Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ShipmentItem_Catalog_Product_ProductId",
                table: "Shipments_ShipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ShipmentItem_Shipments_Shipment_ShipmentId",
                table: "Shipments_ShipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_Country_CountryId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_StateOrProvince_StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_UserId",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_CartItem_ShoppingCart_Cart_CartId",
                table: "ShoppingCart_CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_CartItem_Catalog_Product_ProductId",
                table: "ShoppingCart_CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Tax_TaxRate_Core_Country_CountryId",
                table: "Tax_TaxRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Tax_TaxRate_Core_StateOrProvince_StateOrProvinceId",
                table: "Tax_TaxRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Tax_TaxRate_Tax_TaxClass_TaxClassId",
                table: "Tax_TaxRate");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_Activity_ActivityLog_ActivityType_ActivityTypeId",
                table: "ActivityLog_Activity",
                column: "ActivityTypeId",
                principalTable: "ActivityLog_ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Category_Catalog_Category_ParentId",
                table: "Catalog_Category",
                column: "ParentId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Category_Core_Media_ThumbnailImageId",
                table: "Catalog_Category",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Catalog_Brand_BrandId",
                table: "Catalog_Product",
                column: "BrandId",
                principalTable: "Catalog_Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_User_CreatedById",
                table: "Catalog_Product",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Tax_TaxClass_TaxClassId",
                table: "Catalog_Product",
                column: "TaxClassId",
                principalTable: "Tax_TaxClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_Media_ThumbnailImageId",
                table: "Catalog_Product",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_User_UpdatedById",
                table: "Catalog_Product",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductAttribute_Catalog_ProductAttributeGroup_GroupId",
                table: "Catalog_ProductAttribute",
                column: "GroupId",
                principalTable: "Catalog_ProductAttributeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductAttributeValue_Catalog_ProductAttribute_AttributeId",
                table: "Catalog_ProductAttributeValue",
                column: "AttributeId",
                principalTable: "Catalog_ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductAttributeValue_Catalog_Product_ProductId",
                table: "Catalog_ProductAttributeValue",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductCategory_Catalog_Category_CategoryId",
                table: "Catalog_ProductCategory",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductCategory_Catalog_Product_ProductId",
                table: "Catalog_ProductCategory",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductMedia_Core_Media_MediaId",
                table: "Catalog_ProductMedia",
                column: "MediaId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductMedia_Catalog_Product_ProductId",
                table: "Catalog_ProductMedia",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_ProductOption_OptionId",
                table: "Catalog_ProductOptionCombination",
                column: "OptionId",
                principalTable: "Catalog_ProductOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionCombination",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionValue_Catalog_ProductOption_OptionId",
                table: "Catalog_ProductOptionValue",
                column: "OptionId",
                principalTable: "Catalog_ProductOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionValue_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionValue",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_MenuItem_Core_Entity_EntityId",
                table: "Cms_MenuItem",
                column: "EntityId",
                principalTable: "Core_Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_MenuItem_Cms_Menu_MenuId",
                table: "Cms_MenuItem",
                column: "MenuId",
                principalTable: "Cms_Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_MenuItem_Cms_MenuItem_ParentId",
                table: "Cms_MenuItem",
                column: "ParentId",
                principalTable: "Cms_MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_Page_Core_User_CreatedById",
                table: "Cms_Page",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_Page_Core_User_UpdatedById",
                table: "Cms_Page",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Contact_Contacts_ContactArea_ContactAreaId",
                table: "Contacts_Contact",
                column: "ContactAreaId",
                principalTable: "Contacts_ContactArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_District_Core_StateOrProvince_StateOrProvinceId",
                table: "Core_District",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Entity_Core_EntityType_EntityTypeId",
                table: "Core_Entity",
                column: "EntityTypeId",
                principalTable: "Core_EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_StateOrProvince_Core_Country_CountryId",
                table: "Core_StateOrProvince",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_User_Core_Vendor_VendorId",
                table: "Core_User",
                column: "VendorId",
                principalTable: "Core_Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserAddress_Core_Address_AddressId",
                table: "Core_UserAddress",
                column: "AddressId",
                principalTable: "Core_Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Core_UserCustomerGroup",
                column: "CustomerGroupId",
                principalTable: "Core_CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserCustomerGroup_Core_User_UserId",
                table: "Core_UserCustomerGroup",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserRole_Core_Role_RoleId",
                table: "Core_UserRole",
                column: "RoleId",
                principalTable: "Core_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserRole_Core_User_UserId",
                table: "Core_UserRole",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_WidgetInstance_Core_Widget_WidgetId",
                table: "Core_WidgetInstance",
                column: "WidgetId",
                principalTable: "Core_Widget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_WidgetInstance_Core_WidgetZone_WidgetZoneId",
                table: "Core_WidgetInstance",
                column: "WidgetZoneId",
                principalTable: "Core_WidgetZone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Stock_Catalog_Product_ProductId",
                table: "Inventory_Stock",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_StockHistory_Core_User_CreatedById",
                table: "Inventory_StockHistory",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouse_Core_Address_AddressId",
                table: "Inventory_Warehouse",
                column: "AddressId",
                principalTable: "Core_Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource",
                column: "CultureId",
                principalTable: "Localization_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItem_Core_User_CreatedById",
                table: "News_NewsItem",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItem_Core_Media_ThumbnailImageId",
                table: "News_NewsItem",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItem_Core_User_UpdatedById",
                table: "News_NewsItem",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsCategory_CategoryId",
                table: "News_NewsItemCategory",
                column: "CategoryId",
                principalTable: "News_NewsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsItem_NewsItemId",
                table: "News_NewsItemCategory",
                column: "NewsItemId",
                principalTable: "News_NewsItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Core_User_CreatedById",
                table: "Orders_Order",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_Order_ParentId",
                table: "Orders_Order",
                column: "ParentId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHistory_Orders_Order_OrderId",
                table: "Orders_OrderHistory",
                column: "OrderId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_Orders_Order_OrderId",
                table: "Orders_OrderItem",
                column: "OrderId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_Catalog_Product_ProductId",
                table: "Orders_OrderItem",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Payment_Orders_Order_OrderId",
                table: "Payments_Payment",
                column: "OrderId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCategory",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCategory_Catalog_Category_CategoryId",
                table: "Pricing_CartRuleCategory",
                column: "CategoryId",
                principalTable: "Catalog_Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCustomerGroup",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Pricing_CartRuleCustomerGroup",
                column: "CustomerGroupId",
                principalTable: "Core_CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleProduct",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleProduct_Catalog_Product_ProductId",
                table: "Pricing_CartRuleProduct",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleUsage_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleUsage",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleUsage_Core_User_UserId",
                table: "Pricing_CartRuleUsage",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CatalogRule_CatalogRuleId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CatalogRuleId",
                principalTable: "Pricing_CatalogRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CustomerGroupId",
                principalTable: "Core_CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                table: "Pricing_Coupon",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CouponUsage_Pricing_Coupon_CouponId",
                table: "Pricing_CouponUsage",
                column: "CouponId",
                principalTable: "Pricing_Coupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CouponUsage_Core_User_UserId",
                table: "Pricing_CouponUsage",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComparison_ComparingProduct_Catalog_Product_ProductId",
                table: "ProductComparison_ComparingProduct",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComparison_ComparingProduct_Core_User_UserId",
                table: "ProductComparison_ComparingProduct",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Review_Core_User_UserId",
                table: "Reviews_Review",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ShipmentItem_Catalog_Product_ProductId",
                table: "Shipments_ShipmentItem",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ShipmentItem_Shipments_Shipment_ShipmentId",
                table: "Shipments_ShipmentItem",
                column: "ShipmentId",
                principalTable: "Shipments_Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_Country_CountryId",
                table: "ShippingTableRate_PriceAndDestination",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_StateOrProvince_StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_UserId",
                table: "ShoppingCart_Cart",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_CartItem_ShoppingCart_Cart_CartId",
                table: "ShoppingCart_CartItem",
                column: "CartId",
                principalTable: "ShoppingCart_Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_CartItem_Catalog_Product_ProductId",
                table: "ShoppingCart_CartItem",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tax_TaxRate_Core_Country_CountryId",
                table: "Tax_TaxRate",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tax_TaxRate_Core_StateOrProvince_StateOrProvinceId",
                table: "Tax_TaxRate",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tax_TaxRate_Tax_TaxClass_TaxClassId",
                table: "Tax_TaxRate",
                column: "TaxClassId",
                principalTable: "Tax_TaxClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
