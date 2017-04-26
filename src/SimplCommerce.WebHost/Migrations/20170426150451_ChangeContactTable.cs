using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class ChangeContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Contact_Core_User_CreatedById",
                table: "Contact_Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Contact_Core_User_UpdatedById",
                table: "Contact_Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_Contact_CreatedById",
                table: "Contact_Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_Contact_UpdatedById",
                table: "Contact_Contact");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Contact_Contact");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Contact_Contact");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Contact_Contact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "Contact_Contact",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedById",
                table: "Contact_Contact",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Contact_Contact",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Contact_CreatedById",
                table: "Contact_Contact",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Contact_UpdatedById",
                table: "Contact_Contact",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Contact_Core_User_CreatedById",
                table: "Contact_Contact",
                column: "CreatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Contact_Core_User_UpdatedById",
                table: "Contact_Contact",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
