using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class FreeShipDecreaseMinOrderAmountTo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shipping_ShippingProvider",
                keyColumn: "Id",
                keyValue: "FreeShip",
                column: "AdditionalSettings",
                value: "{MinimumOrderAmount : 1}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shipping_ShippingProvider",
                keyColumn: "Id",
                keyValue: "FreeShip",
                column: "AdditionalSettings",
                value: "{MinimumOrderAmount : 100}");
        }
    }
}
