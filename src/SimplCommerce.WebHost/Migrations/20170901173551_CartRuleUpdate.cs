using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class CartRuleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationOn",
                table: "Pricing_Coupon");

            migrationBuilder.DropColumn(
                name: "UsageLimit",
                table: "Pricing_Coupon");

            migrationBuilder.DropColumn(
                name: "UsageLimitPerCustomer",
                table: "Pricing_Coupon");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxDiscountAmount",
                table: "Pricing_CatalogRule",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "UsageLimitPerCustomer",
                table: "Pricing_CartRule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UsageLimitPerCoupon",
                table: "Pricing_CartRule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxDiscountAmount",
                table: "Pricing_CartRule",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "DiscountStep",
                table: "Pricing_CartRule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpirationOn",
                table: "Pricing_Coupon",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsageLimit",
                table: "Pricing_Coupon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsageLimitPerCustomer",
                table: "Pricing_Coupon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxDiscountAmount",
                table: "Pricing_CatalogRule",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsageLimitPerCustomer",
                table: "Pricing_CartRule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsageLimitPerCoupon",
                table: "Pricing_CartRule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxDiscountAmount",
                table: "Pricing_CartRule",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountStep",
                table: "Pricing_CartRule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
