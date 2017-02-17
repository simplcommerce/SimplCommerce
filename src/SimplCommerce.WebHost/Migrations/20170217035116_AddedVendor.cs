using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Orders_Order",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VendorId",
                table: "Orders_Order",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VendorId",
                table: "Core_User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VendorId",
                table: "Catalog_Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Core_Vendor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Vendor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_ParentId",
                table: "Orders_Order",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order",
                column: "BillingAddressId",
                principalTable: "Orders_OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_Order_ParentId",
                table: "Orders_Order",
                column: "ParentId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Orders_Order_ParentId",
                table: "Orders_Order");

            migrationBuilder.DropTable(
                name: "Core_Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Order_ParentId",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Core_User");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Catalog_Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Orders_OrderAddress_BillingAddressId",
                table: "Orders_Order",
                column: "BillingAddressId",
                principalTable: "Orders_OrderAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
