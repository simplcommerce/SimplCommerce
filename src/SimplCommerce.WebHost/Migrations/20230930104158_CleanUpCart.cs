using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplCommerce.WebHost.Migrations
{
    /// <inheritdoc />
    public partial class CleanUpCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockedOnCheckout",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "ShippingAmount",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "ShippingData",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "ShippingMethod",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "ShoppingCart_Cart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LockedOnCheckout",
                table: "ShoppingCart_Cart",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "ShoppingCart_Cart",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingAmount",
                table: "ShoppingCart_Cart",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingData",
                table: "ShoppingCart_Cart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingMethod",
                table: "ShoppingCart_Cart",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "ShoppingCart_Cart",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
