using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class SeperatedCartAndOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders_CartItem");

            migrationBuilder.DropTable(
                name: "Orders_Cart");

            migrationBuilder.CreateTable(
                name: "ShoppingCart_Cart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponRuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Cart_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart_CartItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_CartItem_ShoppingCart_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "ShoppingCart_Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_CartItem_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_Cart_UserId",
                table: "ShoppingCart_Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CartItem_CartId",
                table: "ShoppingCart_CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CartItem_ProductId",
                table: "ShoppingCart_CartItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCart_CartItem");

            migrationBuilder.DropTable(
                name: "ShoppingCart_Cart");

            migrationBuilder.CreateTable(
                name: "Orders_Cart",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CouponCode = table.Column<string>(nullable: true),
                    CouponRuleName = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cart_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders_CartItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_CartItem_Orders_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Orders_Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_CartItem_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Cart_UserId",
                table: "Orders_Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_CartId",
                table: "Orders_CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_ProductId",
                table: "Orders_CartItem",
                column: "ProductId");
        }
    }
}
