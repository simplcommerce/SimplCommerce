using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class SeoTitleToSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeoTitle",
                table: "News_NewsItem",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "SeoTitle",
                table: "News_NewsCategory",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "SeoTitle",
                table: "Core_Vendor",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "SeoTitle",
                table: "Cms_Page",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "SeoTitle",
                table: "Catalog_Product",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "SeoTitle",
                table: "Catalog_Category",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "SeoTitle",
                table: "Catalog_Brand",
                newName: "Slug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "News_NewsItem",
                newName: "SeoTitle");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "News_NewsCategory",
                newName: "SeoTitle");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Core_Vendor",
                newName: "SeoTitle");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Cms_Page",
                newName: "SeoTitle");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Catalog_Product",
                newName: "SeoTitle");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Catalog_Category",
                newName: "SeoTitle");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Catalog_Brand",
                newName: "SeoTitle");
        }
    }
}
