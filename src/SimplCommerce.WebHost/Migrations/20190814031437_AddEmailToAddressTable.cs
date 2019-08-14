using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddEmailToAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Inventory_Warehouse");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Inventory_Warehouse");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Core_Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Core_Address");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Inventory_Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Inventory_Warehouse",
                nullable: true);
        }
    }
}
