using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class Core_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Core_UrlSlug");

            migrationBuilder.CreateTable(
                name: "Core_Entity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<long>(nullable: false),
                    EntityTypeId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Entity_Core_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "Core_EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Core_Entity_EntityTypeId",
                table: "Core_Entity",
                column: "EntityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Core_Entity");

            migrationBuilder.CreateTable(
                name: "Core_UrlSlug",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<long>(nullable: false),
                    EntityTypeId = table.Column<long>(nullable: false),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UrlSlug", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_UrlSlug_Core_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "Core_EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Core_UrlSlug_EntityTypeId",
                table: "Core_UrlSlug",
                column: "EntityTypeId");
        }
    }
}
