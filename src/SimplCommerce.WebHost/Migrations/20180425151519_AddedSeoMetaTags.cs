using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedSeoMetaTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "News_NewsCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "News_NewsCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "News_NewsCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Catalog_Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "Catalog_Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Catalog_Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "News_NewsCategory");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "News_NewsCategory");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "News_NewsCategory");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Catalog_Category");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "Catalog_Category");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Catalog_Category");
        }
    }
}
