using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class ProductSpecialPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SpecialPrice",
                table: "Catalog_Product",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SpecialPriceEnd",
                table: "Catalog_Product",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SpecialPriceStart",
                table: "Catalog_Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialPrice",
                table: "Catalog_Product");

            migrationBuilder.DropColumn(
                name: "SpecialPriceEnd",
                table: "Catalog_Product");

            migrationBuilder.DropColumn(
                name: "SpecialPriceStart",
                table: "Catalog_Product");
        }
    }
}
