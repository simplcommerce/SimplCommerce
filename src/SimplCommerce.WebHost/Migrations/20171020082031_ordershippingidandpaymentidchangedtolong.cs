using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class ordershippingidandpaymentidchangedtolong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ShippingMethodId",
                table: "Orders_Order",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "PaymentMethodId",
                table: "Orders_Order",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShippingMethodId",
                table: "Orders_Order",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "Orders_Order",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
