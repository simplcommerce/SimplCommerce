using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class OrderAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_UserAddress_CurrentShippingAddressId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Core_UserAddress_BillingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Core_UserAddress_ShippingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropIndex(
                name: "IX_Core_UserRole_UserId",
                table: "Core_UserRole");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Core_Role");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_ProductTemplateProductAttribute_ProductTemplateId",
                table: "Catalog_ProductTemplateProductAttribute");

            migrationBuilder.RenameColumn(
                name: "CurrentShippingAddressId",
                table: "Core_User",
                newName: "DefaultShippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_User_CurrentShippingAddressId",
                table: "Core_User",
                newName: "IX_Core_User_DefaultShippingAddressId");

            migrationBuilder.AlterColumn<long>(
                name: "BillingAddressId",
                table: "Orders_Order",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DefaultBillingAddressId",
                table: "Core_User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders_OrderAddress",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    StateOrProvinceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_OrderAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderAddress_Core_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Core_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderAddress_Core_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Core_District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderAddress_Core_StateOrProvince_StateOrProvinceId",
                        column: x => x.StateOrProvinceId,
                        principalTable: "Core_StateOrProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Core_User_DefaultBillingAddressId",
                table: "Core_User",
                column: "DefaultBillingAddressId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Core_Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderAddress_CountryId",
                table: "Orders_OrderAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderAddress_DistrictId",
                table: "Orders_OrderAddress",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderAddress_StateOrProvinceId",
                table: "Orders_OrderAddress",
                column: "StateOrProvinceId");

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
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order",
                column: "BillingAddressId",
                principalTable: "Orders_OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_ShippingAddressId",
                table: "Orders_Order",
                column: "ShippingAddressId",
                principalTable: "Orders_OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultBillingAddressId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_UserAddress_DefaultShippingAddressId",
                table: "Core_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_ShippingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropTable(
                name: "Orders_OrderAddress");

            migrationBuilder.DropIndex(
                name: "IX_Core_User_DefaultBillingAddressId",
                table: "Core_User");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Core_Role");

            migrationBuilder.DropColumn(
                name: "DefaultBillingAddressId",
                table: "Core_User");

            migrationBuilder.RenameColumn(
                name: "DefaultShippingAddressId",
                table: "Core_User",
                newName: "CurrentShippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_User_DefaultShippingAddressId",
                table: "Core_User",
                newName: "IX_Core_User_CurrentShippingAddressId");

            migrationBuilder.AlterColumn<long>(
                name: "BillingAddressId",
                table: "Orders_Order",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserRole_UserId",
                table: "Core_UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Core_Role",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductTemplateProductAttribute_ProductTemplateId",
                table: "Catalog_ProductTemplateProductAttribute",
                column: "ProductTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_User_Core_UserAddress_CurrentShippingAddressId",
                table: "Core_User",
                column: "CurrentShippingAddressId",
                principalTable: "Core_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Core_UserAddress_BillingAddressId",
                table: "Orders_Order",
                column: "BillingAddressId",
                principalTable: "Core_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Core_UserAddress_ShippingAddressId",
                table: "Orders_Order",
                column: "ShippingAddressId",
                principalTable: "Core_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
