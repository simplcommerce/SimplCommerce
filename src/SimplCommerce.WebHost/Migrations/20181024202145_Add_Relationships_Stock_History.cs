using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class Add_Relationships_Stock_History : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StockHistory_ProductId",
                table: "Inventory_StockHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StockHistory_WareHouseId",
                table: "Inventory_StockHistory",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_StockHistory_Catalog_Product_ProductId",
                table: "Inventory_StockHistory",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_StockHistory_Inventory_Warehouse_WareHouseId",
                table: "Inventory_StockHistory",
                column: "WareHouseId",
                principalTable: "Inventory_Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_StockHistory_Catalog_Product_ProductId",
                table: "Inventory_StockHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_StockHistory_Inventory_Warehouse_WareHouseId",
                table: "Inventory_StockHistory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_StockHistory_ProductId",
                table: "Inventory_StockHistory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_StockHistory_WareHouseId",
                table: "Inventory_StockHistory");
        }
    }
}
