using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class paymentcostandshippingcostadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CalculatedPayCharges",
                table: "Orders_Cart",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CalculatedShippingCharges",
                table: "Orders_Cart",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GranTotal",
                table: "Orders_Cart",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculatedPayCharges",
                table: "Orders_Cart");

            migrationBuilder.DropColumn(
                name: "CalculatedShippingCharges",
                table: "Orders_Cart");

            migrationBuilder.DropColumn(
                name: "GranTotal",
                table: "Orders_Cart");
        }
    }
}
