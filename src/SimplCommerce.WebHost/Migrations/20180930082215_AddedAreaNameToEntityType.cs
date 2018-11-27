using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedAreaNameToEntityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoutingController",
                table: "Core_EntityType",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoutingAction",
                table: "Core_EntityType",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "Core_EntityType",
                maxLength: 450,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Core_EntityType",
                keyColumn: "Id",
                keyValue: "Brand",
                column: "AreaName",
                value: "Catalog");

            migrationBuilder.UpdateData(
                table: "Core_EntityType",
                keyColumn: "Id",
                keyValue: "Category",
                column: "AreaName",
                value: "Catalog");

            migrationBuilder.UpdateData(
                table: "Core_EntityType",
                keyColumn: "Id",
                keyValue: "NewsCategory",
                column: "AreaName",
                value: "News");

            migrationBuilder.UpdateData(
                table: "Core_EntityType",
                keyColumn: "Id",
                keyValue: "NewsItem",
                column: "AreaName",
                value: "News");

            migrationBuilder.UpdateData(
                table: "Core_EntityType",
                keyColumn: "Id",
                keyValue: "Page",
                column: "AreaName",
                value: "Cms");

            migrationBuilder.UpdateData(
                table: "Core_EntityType",
                keyColumn: "Id",
                keyValue: "Product",
                column: "AreaName",
                value: "Catalog");

            migrationBuilder.UpdateData(
                table: "Core_EntityType",
                keyColumn: "Id",
                keyValue: "Vendor",
                column: "AreaName",
                value: "Core");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "Core_EntityType");

            migrationBuilder.AlterColumn<string>(
                name: "RoutingController",
                table: "Core_EntityType",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoutingAction",
                table: "Core_EntityType",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
