using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedStockHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Orders_Order",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservedQuantity",
                table: "Inventory_Stock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Catalog_Product");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Catalog_Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Inventory_StockHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdjustedQuantity = table.Column<long>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    WareHouseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_StockHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_StockHistory_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Stock_ProductId",
                table: "Inventory_Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StockHistory_CreatedById",
                table: "Inventory_StockHistory",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Stock_Catalog_Product_ProductId",
                table: "Inventory_Stock",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Stock_Catalog_Product_ProductId",
                table: "Inventory_Stock");

            migrationBuilder.DropTable(
                name: "Inventory_StockHistory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Stock_ProductId",
                table: "Inventory_Stock");

            migrationBuilder.DropColumn(
                name: "ReservedQuantity",
                table: "Inventory_Stock");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Orders_Order",
                nullable: true,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<int>(
                name: "StockQuantity",
                table: "Catalog_Product",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
