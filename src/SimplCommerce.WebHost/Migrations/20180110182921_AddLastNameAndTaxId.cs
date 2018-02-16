using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddLastNameAndTaxId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders_OrderAddress",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxId",
                table: "Orders_OrderAddress",
                type: "int8",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders_OrderAddress");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "Orders_OrderAddress");
        }
    }
}
