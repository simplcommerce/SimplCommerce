using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class PricingCartRuleCatalogFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pricing_CatalogRuleCustomerGroup",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropIndex(
                name: "IX_Pricing_CatalogRuleCustomerGroup_CartRuleId",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropIndex(
                name: "IX_Pricing_CatalogRuleCustomerGroup_CatalogRuleId",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropColumn(
                name: "CartRuleId",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pricing_CatalogRuleCustomerGroup",
                table: "Pricing_CatalogRuleCustomerGroup",
                columns: new[] { "CatalogRuleId", "CustomerGroupId" });

            migrationBuilder.CreateTable(
                name: "Pricing_CartRuleCategory",
                columns: table => new
                {
                    CartRuleId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CartRuleCategory", x => new { x.CartRuleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                        column: x => x.CartRuleId,
                        principalTable: "Pricing_CartRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pricing_CartRuleCategory_Catalog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Catalog_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pricing_CartRuleCustomerGroup",
                columns: table => new
                {
                    CartRuleId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerGroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CartRuleCustomerGroup", x => new { x.CartRuleId, x.CustomerGroupId });
                    table.ForeignKey(
                        name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                        column: x => x.CartRuleId,
                        principalTable: "Pricing_CartRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pricing_CartRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "Core_CustomerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pricing_CartRuleProduct",
                columns: table => new
                {
                    CartRuleId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CartRuleProduct", x => new { x.CartRuleId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                        column: x => x.CartRuleId,
                        principalTable: "Pricing_CartRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pricing_CartRuleProduct_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CartRuleCategory_CategoryId",
                table: "Pricing_CartRuleCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CartRuleCustomerGroup_CustomerGroupId",
                table: "Pricing_CartRuleCustomerGroup",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CartRuleProduct_ProductId",
                table: "Pricing_CartRuleProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pricing_CartRuleCategory");

            migrationBuilder.DropTable(
                name: "Pricing_CartRuleCustomerGroup");

            migrationBuilder.DropTable(
                name: "Pricing_CartRuleProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pricing_CatalogRuleCustomerGroup",
                table: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Pricing_CatalogRuleCustomerGroup",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "CartRuleId",
                table: "Pricing_CatalogRuleCustomerGroup",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pricing_CatalogRuleCustomerGroup",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CatalogRuleCustomerGroup_CartRuleId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CartRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CatalogRuleCustomerGroup_CatalogRuleId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CatalogRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
