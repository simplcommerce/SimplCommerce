using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedTaxModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code2",
                table: "Core_Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code3",
                table: "Core_Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBillingEnabled",
                table: "Core_Country",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShippingEnabled",
                table: "Core_Country",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "TaxClassId",
                table: "Catalog_Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tax_TaxClass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax_TaxClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tax_TaxRate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StateOrProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    TaxClassId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax_TaxRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tax_TaxRate_Core_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Core_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tax_TaxRate_Core_StateOrProvince_StateOrProvinceId",
                        column: x => x.StateOrProvinceId,
                        principalTable: "Core_StateOrProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tax_TaxRate_Tax_TaxClass_TaxClassId",
                        column: x => x.TaxClassId,
                        principalTable: "Tax_TaxClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Product_TaxClassId",
                table: "Catalog_Product",
                column: "TaxClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_TaxRate_CountryId",
                table: "Tax_TaxRate",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_TaxRate_StateOrProvinceId",
                table: "Tax_TaxRate",
                column: "StateOrProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_TaxRate_TaxClassId",
                table: "Tax_TaxRate",
                column: "TaxClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Tax_TaxClass_TaxClassId",
                table: "Catalog_Product",
                column: "TaxClassId",
                principalTable: "Tax_TaxClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Tax_TaxClass_TaxClassId",
                table: "Catalog_Product");

            migrationBuilder.DropTable(
                name: "Tax_TaxRate");

            migrationBuilder.DropTable(
                name: "Tax_TaxClass");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Product_TaxClassId",
                table: "Catalog_Product");

            migrationBuilder.DropColumn(
                name: "Code2",
                table: "Core_Country");

            migrationBuilder.DropColumn(
                name: "Code3",
                table: "Core_Country");

            migrationBuilder.DropColumn(
                name: "IsBillingEnabled",
                table: "Core_Country");

            migrationBuilder.DropColumn(
                name: "IsShippingEnabled",
                table: "Core_Country");

            migrationBuilder.DropColumn(
                name: "TaxClassId",
                table: "Catalog_Product");
        }
    }
}
