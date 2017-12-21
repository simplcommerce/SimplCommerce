using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedTaxedToOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingPrice",
                table: "Orders_Order");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "Orders_OrderItem",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercent",
                table: "Orders_OrderItem",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingAmount",
                table: "Orders_Order",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "Orders_Order",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Orders_OrderItem");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "Orders_OrderItem");

            migrationBuilder.DropColumn(
                name: "ShippingAmount",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Orders_Order");

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingPrice",
                table: "Orders_Order",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
