using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddProductComparison : Migration
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

            migrationBuilder.CreateTable(
                name: "ProductComparison_ProductComparisonItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComparison_ProductComparisonItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComparison_ProductComparisonItem_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComparison_ProductComparisonItem_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductComparison_ProductComparisonItem_ProductId",
                table: "ProductComparison_ProductComparisonItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComparison_ProductComparisonItem_UserId",
                table: "ProductComparison_ProductComparisonItem",
                column: "UserId");

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
                name: "ProductComparison_ProductComparisonItem");

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
