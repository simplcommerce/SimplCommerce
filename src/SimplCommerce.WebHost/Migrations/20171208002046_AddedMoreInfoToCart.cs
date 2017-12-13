using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedMoreInfoToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ShippingAmount",
                table: "ShoppingCart_Cart",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingMethod",
                table: "ShoppingCart_Cart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "ShoppingCart_Cart",
                type: "decimal(18, 2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingAmount",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "ShippingMethod",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "ShoppingCart_Cart");
        }
    }
}
