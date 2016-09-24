using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class EntityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityName",
                table: "Core_UrlSlug");

            migrationBuilder.CreateTable(
                name: "Core_EntityType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RoutingAction = table.Column<string>(nullable: true),
                    RoutingController = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_EntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Search_Query",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    QueryText = table.Column<string>(nullable: true),
                    ResultsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Search_Query", x => x.Id);
                });

            migrationBuilder.AddColumn<long>(
                name: "EntityTypeId",
                table: "Core_UrlSlug",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<float>(
                name: "RatingAverage",
                table: "Catalog_Product",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ReviewsCount",
                table: "Catalog_Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Core_UrlSlug_EntityTypeId",
                table: "Core_UrlSlug",
                column: "EntityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UrlSlug_Core_EntityType_EntityTypeId",
                table: "Core_UrlSlug",
                column: "EntityTypeId",
                principalTable: "Core_EntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_UrlSlug_Core_EntityType_EntityTypeId",
                table: "Core_UrlSlug");

            migrationBuilder.DropIndex(
                name: "IX_Core_UrlSlug_EntityTypeId",
                table: "Core_UrlSlug");

            migrationBuilder.DropColumn(
                name: "EntityTypeId",
                table: "Core_UrlSlug");

            migrationBuilder.DropColumn(
                name: "RatingAverage",
                table: "Catalog_Product");

            migrationBuilder.DropColumn(
                name: "ReviewsCount",
                table: "Catalog_Product");

            migrationBuilder.DropTable(
                name: "Core_EntityType");

            migrationBuilder.DropTable(
                name: "Search_Query");

            migrationBuilder.AddColumn<string>(
                name: "EntityName",
                table: "Core_UrlSlug",
                nullable: true);
        }
    }
}
