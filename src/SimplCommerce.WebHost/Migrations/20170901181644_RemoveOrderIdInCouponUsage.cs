using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class RemoveOrderIdInCouponUsage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Pricing_CouponUsage");

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotalWithDiscount",
                table: "Orders_Order",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotalWithDiscount",
                table: "Orders_Order");

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "Pricing_CouponUsage",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
