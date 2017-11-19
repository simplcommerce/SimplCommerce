using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedNoteToPriceAndDestination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropColumn(
                name: "StateOrProvince",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "ShippingTableRate_PriceAndDestination",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ShippingTableRate_PriceAndDestination",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Core_StateOrProvince",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Core_StateOrProvince",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingTableRate_PriceAndDestination_CountryId",
                table: "ShippingTableRate_PriceAndDestination",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingTableRate_PriceAndDestination_StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination",
                column: "StateOrProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_Country_CountryId",
                table: "ShippingTableRate_PriceAndDestination",
                column: "CountryId",
                principalTable: "Core_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_StateOrProvince_StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination",
                column: "StateOrProvinceId",
                principalTable: "Core_StateOrProvince",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_Country_CountryId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingTableRate_PriceAndDestination_Core_StateOrProvince_StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropIndex(
                name: "IX_ShippingTableRate_PriceAndDestination_CountryId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropIndex(
                name: "IX_ShippingTableRate_PriceAndDestination_StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropColumn(
                name: "StateOrProvinceId",
                table: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Core_StateOrProvince");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Core_StateOrProvince");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ShippingTableRate_PriceAndDestination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateOrProvince",
                table: "ShippingTableRate_PriceAndDestination",
                nullable: true);
        }
    }
}
