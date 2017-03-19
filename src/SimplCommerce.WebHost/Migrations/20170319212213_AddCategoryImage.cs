using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddCategoryImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Catalog_Category");

            migrationBuilder.AddColumn<long>(
                name: "ThumbnailImageId",
                table: "Catalog_Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Category_ThumbnailImageId",
                table: "Catalog_Category",
                column: "ThumbnailImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Category_Core_Media_ThumbnailImageId",
                table: "Catalog_Category",
                column: "ThumbnailImageId",
                principalTable: "Core_Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Category_Core_Media_ThumbnailImageId",
                table: "Catalog_Category");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Category_ThumbnailImageId",
                table: "Catalog_Category");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Catalog_Category");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Catalog_Category",
                nullable: true);
        }
    }
}
