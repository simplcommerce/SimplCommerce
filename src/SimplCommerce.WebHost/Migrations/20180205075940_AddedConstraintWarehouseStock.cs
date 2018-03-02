using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedConstraintWarehouseStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inventory_Warehouse",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Stock_WarehouseId",
                table: "Inventory_Stock",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Stock_Inventory_Warehouse_WarehouseId",
                table: "Inventory_Stock",
                column: "WarehouseId",
                principalTable: "Inventory_Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Stock_Inventory_Warehouse_WarehouseId",
                table: "Inventory_Stock");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Stock_WarehouseId",
                table: "Inventory_Stock");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inventory_Warehouse",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
