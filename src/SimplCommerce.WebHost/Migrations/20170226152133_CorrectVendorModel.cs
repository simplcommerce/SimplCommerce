using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class CorrectVendorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "VendorId",
                table: "Orders_Order",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Core_Vendor",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Core_Vendor",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<long>(
                name: "VendorId",
                table: "Core_User",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VendorId",
                table: "Catalog_Product",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Core_User_VendorId",
                table: "Core_User",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_User_Core_Vendor_VendorId",
                table: "Core_User",
                column: "VendorId",
                principalTable: "Core_Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_User_Core_Vendor_VendorId",
                table: "Core_User");

            migrationBuilder.DropIndex(
                name: "IX_Core_User_VendorId",
                table: "Core_User");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Core_Vendor");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Core_Vendor");

            migrationBuilder.AlterColumn<bool>(
                name: "VendorId",
                table: "Orders_Order",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "VendorId",
                table: "Core_User",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "VendorId",
                table: "Catalog_Product",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
