using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class ProductOptionSortIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionCombination");

            migrationBuilder.DropColumn(
                name: "ProducdtId",
                table: "Catalog_ProductOptionCombination");

            migrationBuilder.AddColumn<int>(
                name: "SortIndex",
                table: "Catalog_ProductOptionValue",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortIndex",
                table: "Catalog_ProductOptionCombination",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropIndex("IX_Catalog_ProductOptionCombination_ProductId", table: "Catalog_ProductOptionCombination");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Catalog_ProductOptionCombination",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionCombination",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductOptionCombination_ProductId",
                table: "Catalog_ProductOptionCombination",
                column: "ProductId");
            }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionCombination");

            migrationBuilder.DropColumn(
                name: "SortIndex",
                table: "Catalog_ProductOptionValue");

            migrationBuilder.DropColumn(
                name: "SortIndex",
                table: "Catalog_ProductOptionCombination");

            migrationBuilder.AddColumn<long>(
                name: "ProducdtId",
                table: "Catalog_ProductOptionCombination",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Catalog_ProductOptionCombination",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                table: "Catalog_ProductOptionCombination",
                column: "ProductId",
                principalTable: "Catalog_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
