using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class InventoryForVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VendorId",
                table: "Shipments_Shipment",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "Localization_Culture",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<long>(
                name: "VendorId",
                table: "Inventory_Warehouse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Shipments_Shipment");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Inventory_Warehouse");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "Localization_Culture",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
