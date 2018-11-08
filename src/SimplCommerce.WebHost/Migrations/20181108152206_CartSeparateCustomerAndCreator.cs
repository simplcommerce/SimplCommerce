using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class CartSeparateCustomerAndCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_UserId",
                table: "ShoppingCart_Cart");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCart_Cart",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_Cart_UserId",
                table: "ShoppingCart_Cart",
                newName: "IX_ShoppingCart_Cart_CustomerId");

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "ShoppingCart_Cart",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_Cart_CreatedById",
                table: "ShoppingCart_Cart",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_CreatedById",
                table: "ShoppingCart_Cart",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_CustomerId",
                table: "ShoppingCart_Cart",
                column: "CustomerId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_CreatedById",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_CustomerId",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_Cart_CreatedById",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ShoppingCart_Cart");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ShoppingCart_Cart",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_Cart_CustomerId",
                table: "ShoppingCart_Cart",
                newName: "IX_ShoppingCart_Cart_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Cart_Core_User_UserId",
                table: "ShoppingCart_Cart",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
