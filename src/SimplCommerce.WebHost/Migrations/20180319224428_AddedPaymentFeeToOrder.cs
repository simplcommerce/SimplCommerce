using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedPaymentFeeToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAmount",
                table: "Orders_Order",
                newName: "ShippingFeeAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentFeeAmount",
                table: "Orders_Order",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentFeeAmount",
                table: "Orders_Order");

            migrationBuilder.RenameColumn(
                name: "ShippingFeeAmount",
                table: "Orders_Order",
                newName: "ShippingAmount");
        }
    }
}
