using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class CascadeNewsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsCategory_CategoryId",
                table: "News_NewsItemCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsItem_NewsItemId",
                table: "News_NewsItemCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsCategory_CategoryId",
                table: "News_NewsItemCategory",
                column: "CategoryId",
                principalTable: "News_NewsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsItem_NewsItemId",
                table: "News_NewsItemCategory",
                column: "NewsItemId",
                principalTable: "News_NewsItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsCategory_CategoryId",
                table: "News_NewsItemCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsItem_NewsItemId",
                table: "News_NewsItemCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsCategory_CategoryId",
                table: "News_NewsItemCategory",
                column: "CategoryId",
                principalTable: "News_NewsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItemCategory_News_NewsItem_NewsItemId",
                table: "News_NewsItemCategory",
                column: "NewsItemId",
                principalTable: "News_NewsItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
