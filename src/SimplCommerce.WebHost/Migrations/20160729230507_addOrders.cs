using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class addOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders_CartItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_CartItem_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_CartItem_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders_Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillingAddressId = table.Column<long>(nullable: true),
                    CreatedById = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    ShippingAddressId = table.Column<long>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Order_Core_UserAddress_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Core_UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Order_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Order_Core_UserAddress_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Core_UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders_OrderItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderItem_Orders_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderItem_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_ProductId",
                table: "Orders_CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_UserId",
                table: "Orders_CartItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_BillingAddressId",
                table: "Orders_Order",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_CreatedById",
                table: "Orders_Order",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_ShippingAddressId",
                table: "Orders_Order",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItem_OrderId",
                table: "Orders_OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItem_ProductId",
                table: "Orders_OrderItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders_CartItem");

            migrationBuilder.DropTable(
                name: "Orders_OrderItem");

            migrationBuilder.DropTable(
                name: "Orders_Order");
        }
    }
}
