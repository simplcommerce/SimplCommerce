using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class CreatedUpdatedConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LatestUpdatedById",
                table: "Orders_Order",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "LatestUpdatedById",
                table: "News_NewsItem",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "News_NewsItem",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LatestUpdatedById",
                table: "Cms_Page",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Cms_Page",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Catalog_ProductPriceHistory",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LatestUpdatedById",
                table: "Catalog_Product",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Catalog_Product",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_LatestUpdatedById",
                table: "Orders_Order",
                column: "LatestUpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Core_User_LatestUpdatedById",
                table: "Orders_Order",
                column: "LatestUpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Core_User_LatestUpdatedById",
                table: "Orders_Order");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Order_LatestUpdatedById",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "LatestUpdatedById",
                table: "Orders_Order");

            migrationBuilder.AlterColumn<long>(
                name: "LatestUpdatedById",
                table: "News_NewsItem",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "News_NewsItem",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "LatestUpdatedById",
                table: "Cms_Page",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Cms_Page",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Catalog_ProductPriceHistory",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "LatestUpdatedById",
                table: "Catalog_Product",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Catalog_Product",
                nullable: true,
                oldClrType: typeof(long));
        }
    }
}
