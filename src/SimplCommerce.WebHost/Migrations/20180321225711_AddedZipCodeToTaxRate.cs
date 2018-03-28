using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedZipCodeToTaxRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Orders_OrderAddress",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "IsPostalCodeEnabled",
                table: "Core_Country",
                newName: "IsZipCodeEnabled");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Core_Address",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Tax_TaxRate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Tax_TaxRate");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Orders_OrderAddress",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "IsZipCodeEnabled",
                table: "Core_Country",
                newName: "IsPostalCodeEnabled");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Core_Address",
                newName: "PostalCode");
        }
    }
}
