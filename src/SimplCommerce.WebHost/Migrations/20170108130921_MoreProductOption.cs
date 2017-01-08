using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class MoreProductOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAllowToOrder",
                table: "Catalog_Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCallForPricing",
                table: "Catalog_Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Catalog_Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAllowToOrder",
                table: "Catalog_Product");

            migrationBuilder.DropColumn(
                name: "IsCallForPricing",
                table: "Catalog_Product");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Catalog_Product");
        }
    }
}
