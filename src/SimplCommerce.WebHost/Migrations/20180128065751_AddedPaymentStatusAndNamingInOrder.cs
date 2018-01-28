using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedPaymentStatusAndNamingInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Orders_Order",
                newName: "DiscountAmount");

            migrationBuilder.AddColumn<string>(
                name: "FailureMessage",
                table: "Payments_Payment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payments_Payment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Orders_OrderItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentItem_ProductId",
                table: "Shipments_ShipmentItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ShipmentItem_Catalog_Product_ProductId",
                table: "Shipments_ShipmentItem",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ShipmentItem_Catalog_Product_ProductId",
                table: "Shipments_ShipmentItem");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ShipmentItem_ProductId",
                table: "Shipments_ShipmentItem");

            migrationBuilder.DropColumn(
                name: "FailureMessage",
                table: "Payments_Payment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payments_Payment");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Orders_OrderItem");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "Orders_Order",
                newName: "Discount");
        }
    }
}
