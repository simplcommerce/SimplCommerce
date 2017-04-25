using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedMenuManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource");

            migrationBuilder.AlterColumn<long>(
                name: "CultureId",
                table: "Localization_Resource",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMenuable",
                table: "Core_EntityType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Cms_Menu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsSystem = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cms_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cms_MenuItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomLink = table.Column<string>(nullable: true),
                    EntityId = table.Column<long>(nullable: true),
                    MenuId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cms_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cms_MenuItem_Core_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Core_Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cms_MenuItem_Cms_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Cms_Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cms_MenuItem_Cms_MenuItem_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Cms_MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cms_MenuItem_EntityId",
                table: "Cms_MenuItem",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cms_MenuItem_MenuId",
                table: "Cms_MenuItem",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Cms_MenuItem_ParentId",
                table: "Cms_MenuItem",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource",
                column: "CultureId",
                principalTable: "Localization_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource");

            migrationBuilder.DropTable(
                name: "Cms_MenuItem");

            migrationBuilder.DropTable(
                name: "Cms_Menu");

            migrationBuilder.DropColumn(
                name: "IsMenuable",
                table: "Core_EntityType");

            migrationBuilder.AlterColumn<long>(
                name: "CultureId",
                table: "Localization_Resource",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource",
                column: "CultureId",
                principalTable: "Localization_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
