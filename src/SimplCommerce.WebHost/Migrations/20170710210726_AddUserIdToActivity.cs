using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddUserIdToActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductLink_Catalog_Product_LinkedProductId",
                table: "Catalog_ProductLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductLink_Catalog_Product_ProductId",
                table: "Catalog_ProductLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Address_Core_Country_CountryId",
                table: "Core_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Address_Core_District_DistrictId",
                table: "Core_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Address_Core_StateOrProvince_StateOrProvinceId",
                table: "Core_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultBillingAddressId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultShippingAddressId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserAddress_Core_User_UserId",
                table: "Core_UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_ShippingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderAddress_Core_Country_CountryId",
                table: "Orders_OrderAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderAddress_Core_District_DistrictId",
                table: "Orders_OrderAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderAddress_Core_StateOrProvince_StateOrProvinceId",
                table: "Orders_OrderAddress");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "Core_User");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Core_Role");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ActivityLog_Activity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Core_User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Core_Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductLink_Catalog_Product_LinkedProductId",
                table: "Catalog_ProductLink",
                column: "LinkedProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductLink_Catalog_Product_ProductId",
                table: "Catalog_ProductLink",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Address_Core_Country_CountryId",
                table: "Core_Address",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Address_Core_District_DistrictId",
                table: "Core_Address",
                column: "DistrictId",
                principalTable: "Core_District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Address_Core_StateOrProvince_StateOrProvinceId",
                table: "Core_Address",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultBillingAddressId",
                table: "Core_User",
                column: "DefaultBillingAddressId",
                principalTable: "Core_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultShippingAddressId",
                table: "Core_User",
                column: "DefaultShippingAddressId",
                principalTable: "Core_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserAddress_Core_User_UserId",
                table: "Core_UserAddress",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserToken_Core_User_UserId",
                table: "Core_UserToken",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order",
                column: "BillingAddressId",
                principalTable: "Orders_OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_ShippingAddressId",
                table: "Orders_Order",
                column: "ShippingAddressId",
                principalTable: "Orders_OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderAddress_Core_Country_CountryId",
                table: "Orders_OrderAddress",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderAddress_Core_District_DistrictId",
                table: "Orders_OrderAddress",
                column: "DistrictId",
                principalTable: "Core_District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderAddress_Core_StateOrProvince_StateOrProvinceId",
                table: "Orders_OrderAddress",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductLink_Catalog_Product_LinkedProductId",
                table: "Catalog_ProductLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductLink_Catalog_Product_ProductId",
                table: "Catalog_ProductLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Address_Core_Country_CountryId",
                table: "Core_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Address_Core_District_DistrictId",
                table: "Core_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_Address_Core_StateOrProvince_StateOrProvinceId",
                table: "Core_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultBillingAddressId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultShippingAddressId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserAddress_Core_User_UserId",
                table: "Core_UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserToken_Core_User_UserId",
                table: "Core_UserToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_ShippingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderAddress_Core_Country_CountryId",
                table: "Orders_OrderAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderAddress_Core_District_DistrictId",
                table: "Orders_OrderAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderAddress_Core_StateOrProvince_StateOrProvinceId",
                table: "Orders_OrderAddress");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "Core_User");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Core_Role");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ActivityLog_Activity");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Core_User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Core_Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductLink_Catalog_Product_LinkedProductId",
                table: "Catalog_ProductLink",
                column: "LinkedProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductLink_Catalog_Product_ProductId",
                table: "Catalog_ProductLink",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Address_Core_Country_CountryId",
                table: "Core_Address",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Address_Core_District_DistrictId",
                table: "Core_Address",
                column: "DistrictId",
                principalTable: "Core_District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_Address_Core_StateOrProvince_StateOrProvinceId",
                table: "Core_Address",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultBillingAddressId",
                table: "Core_User",
                column: "DefaultBillingAddressId",
                principalTable: "Core_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultShippingAddressId",
                table: "Core_User",
                column: "DefaultShippingAddressId",
                principalTable: "Core_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserAddress_Core_User_UserId",
                table: "Core_UserAddress",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order",
                column: "BillingAddressId",
                principalTable: "Orders_OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_ShippingAddressId",
                table: "Orders_Order",
                column: "ShippingAddressId",
                principalTable: "Orders_OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderAddress_Core_Country_CountryId",
                table: "Orders_OrderAddress",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderAddress_Core_District_DistrictId",
                table: "Orders_OrderAddress",
                column: "DistrictId",
                principalTable: "Core_District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderAddress_Core_StateOrProvince_StateOrProvinceId",
                table: "Orders_OrderAddress",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
