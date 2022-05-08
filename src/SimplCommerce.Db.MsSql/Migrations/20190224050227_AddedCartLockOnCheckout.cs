using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.Db.MsSql.Migrations
{
    public partial class AddedCartLockOnCheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LockedOnCheckout",
                table: "ShoppingCart_Cart",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockedOnCheckout",
                table: "ShoppingCart_Cart");
        }
    }
}
