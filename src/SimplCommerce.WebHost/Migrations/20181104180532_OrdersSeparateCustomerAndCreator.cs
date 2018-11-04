using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class OrdersSeparateCustomerAndCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Orders_Order",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_CustomerId",
                table: "Orders_Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Core_User_CustomerId",
                table: "Orders_Order",
                column: "CustomerId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Core_User_CustomerId",
                table: "Orders_Order");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Order_CustomerId",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders_Order");
        }
    }
}
