using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedShippingProviderConfigUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfigureUrl",
                table: "Shipping_ShippingProvider",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingMethod",
                table: "Orders_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingPrice",
                table: "Orders_Order",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfigureUrl",
                table: "Shipping_ShippingProvider");

            migrationBuilder.DropColumn(
                name: "ShippingMethod",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "ShippingPrice",
                table: "Orders_Order");
        }
    }
}
