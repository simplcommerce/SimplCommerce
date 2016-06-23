using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.Web.Migrations
{
    public partial class UpdateCmsWidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WidgetData",
                table: "Cms_WidgetInstance");

            migrationBuilder.DropColumn(
                name: "WidgetZone",
                table: "Cms_WidgetInstance");

            migrationBuilder.CreateTable(
                name: "Cms_WidgetZone",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cms_WidgetZone", x => x.Id);
                });

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Cms_WidgetInstance",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HtmlData",
                table: "Cms_WidgetInstance",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WidgetZoneId",
                table: "Cms_WidgetInstance",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Cms_WidgetInstance_WidgetZoneId",
                table: "Cms_WidgetInstance",
                column: "WidgetZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_WidgetInstance_Cms_WidgetZone_WidgetZoneId",
                table: "Cms_WidgetInstance",
                column: "WidgetZoneId",
                principalTable: "Cms_WidgetZone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cms_WidgetInstance_Cms_WidgetZone_WidgetZoneId",
                table: "Cms_WidgetInstance");

            migrationBuilder.DropIndex(
                name: "IX_Cms_WidgetInstance_WidgetZoneId",
                table: "Cms_WidgetInstance");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Cms_WidgetInstance");

            migrationBuilder.DropColumn(
                name: "HtmlData",
                table: "Cms_WidgetInstance");

            migrationBuilder.DropColumn(
                name: "WidgetZoneId",
                table: "Cms_WidgetInstance");

            migrationBuilder.DropTable(
                name: "Cms_WidgetZone");

            migrationBuilder.AddColumn<string>(
                name: "WidgetData",
                table: "Cms_WidgetInstance",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WidgetZone",
                table: "Cms_WidgetInstance",
                nullable: false,
                defaultValue: 0);
        }
    }
}
