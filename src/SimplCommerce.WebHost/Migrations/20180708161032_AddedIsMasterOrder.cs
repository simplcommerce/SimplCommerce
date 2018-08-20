using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedIsMasterOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMasterOrder",
                table: "Orders_Order",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Warehouse_VendorId",
                table: "Inventory_Warehouse",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouse_Core_Vendor_VendorId",
                table: "Inventory_Warehouse",
                column: "VendorId",
                principalTable: "Core_Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouse_Core_Vendor_VendorId",
                table: "Inventory_Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Warehouse_VendorId",
                table: "Inventory_Warehouse");

            migrationBuilder.DropColumn(
                name: "IsMasterOrder",
                table: "Orders_Order");
        }
    }
}
