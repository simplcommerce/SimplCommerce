using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class RefactorCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CartItem_Core_User_UserId",
                table: "Orders_CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartItem_UserId",
                table: "Orders_CartItem");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders_CartItem");

            migrationBuilder.AddColumn<string>(
                name: "CouponCode",
                table: "Orders_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CouponRuleName",
                table: "Orders_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Orders_Order",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "CartId",
                table: "Orders_CartItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Orders_Cart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponRuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cart_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_CartId",
                table: "Orders_CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Cart_UserId",
                table: "Orders_Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartItem_Orders_Cart_CartId",
                table: "Orders_CartItem",
                column: "CartId",
                principalTable: "Orders_Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CartItem_Orders_Cart_CartId",
                table: "Orders_CartItem");

            migrationBuilder.DropTable(
                name: "Orders_Cart");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartItem_CartId",
                table: "Orders_CartItem");

            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "CouponRuleName",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Orders_CartItem");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Orders_CartItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_UserId",
                table: "Orders_CartItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartItem_Core_User_UserId",
                table: "Orders_CartItem",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
