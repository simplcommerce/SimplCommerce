using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class Move_Default_Culture_To_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Localization_Culture");

            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "Core_User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Culture",
                table: "Core_User");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Localization_Culture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Localization_Culture",
                keyColumn: "Id",
                keyValue: "en-US",
                column: "IsDefault",
                value: true);
        }
    }
}
