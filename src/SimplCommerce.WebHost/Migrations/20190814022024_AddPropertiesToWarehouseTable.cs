using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddPropertiesToWarehouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Inventory_Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "Inventory_Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Inventory_Warehouse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Warehouse_MediaId",
                table: "Inventory_Warehouse",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouse_Core_Media_MediaId",
                table: "Inventory_Warehouse",
                column: "MediaId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouse_Core_Media_MediaId",
                table: "Inventory_Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Warehouse_MediaId",
                table: "Inventory_Warehouse");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Inventory_Warehouse");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Inventory_Warehouse");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Inventory_Warehouse");
        }
    }
}
