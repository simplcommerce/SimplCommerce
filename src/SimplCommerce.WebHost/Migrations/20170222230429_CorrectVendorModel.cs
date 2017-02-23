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

            migrationBuilder.AlterColumn<long>(
                name: "VendorId",
                table: "Core_User",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
