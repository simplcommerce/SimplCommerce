using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.Web.Migrations
{
    public partial class CreateGuestUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CartItem_Core_User_CreatedById",
                table: "Orders_CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartItem_CreatedById",
                table: "Orders_CartItem");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Orders_CartItem");

            migrationBuilder.DropColumn(
                name: "GuestId",
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Core_User",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartItem_Core_User_UserId",
                table: "Orders_CartItem",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Core_User");

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "Orders_CartItem",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuestId",
                table: "Orders_CartItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_CreatedById",
                table: "Orders_CartItem",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartItem_Core_User_CreatedById",
                table: "Orders_CartItem",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
