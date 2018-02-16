using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedCountryFieldDisplayToggles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCityEnabled",
                table: "Core_Country",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDistrictEnabled",
                table: "Core_Country",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPostalCodeEnabled",
                table: "Core_Country",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCityEnabled",
                table: "Core_Country");

            migrationBuilder.DropColumn(
                name: "IsDistrictEnabled",
                table: "Core_Country");

            migrationBuilder.DropColumn(
                name: "IsPostalCodeEnabled",
                table: "Core_Country");
        }
    }
}
