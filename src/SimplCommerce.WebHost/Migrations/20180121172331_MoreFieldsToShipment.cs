using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class MoreFieldsToShipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Shipment_Orders_Order_OrderId",
                table: "Shipments_Shipment");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Shipments_Shipment",
                newName: "WarehouseId");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Shipments_ShipmentItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "Shipments_Shipment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_Shipment_CreatedById",
                table: "Shipments_Shipment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_Shipment_WarehouseId",
                table: "Shipments_Shipment",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Shipment_Core_User_CreatedById",
                table: "Shipments_Shipment",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Shipment_Orders_Order_OrderId",
                table: "Shipments_Shipment",
                column: "OrderId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Shipment_Inventory_Warehouse_WarehouseId",
                table: "Shipments_Shipment",
                column: "WarehouseId",
                principalTable: "Inventory_Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Shipment_Core_User_CreatedById",
                table: "Shipments_Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Shipment_Orders_Order_OrderId",
                table: "Shipments_Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Shipment_Inventory_Warehouse_WarehouseId",
                table: "Shipments_Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_Shipment_CreatedById",
                table: "Shipments_Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_Shipment_WarehouseId",
                table: "Shipments_Shipment");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Shipments_ShipmentItem");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Shipments_Shipment");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Shipments_Shipment",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Shipment_Orders_Order_OrderId",
                table: "Shipments_Shipment",
                column: "OrderId",
                principalTable: "Orders_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
