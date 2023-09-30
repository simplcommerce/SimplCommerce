using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplCommerce.WebHost.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkouts_Checkout",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LatestUpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CouponRuleName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ShippingMethod = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IsProductPriceIncludeTax = table.Column<bool>(type: "bit", nullable: false),
                    ShippingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShippingData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNote = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts_Checkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_Checkout_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_Checkout_Core_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts_CheckoutItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CheckoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts_CheckoutItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_CheckoutItem_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_CheckoutItem_Checkouts_Checkout_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts_Checkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Core_AppSetting",
                columns: new[] { "Id", "IsVisibleInCommonSettingPage", "Module", "Value" },
                values: new object[] { "Global.DefaultCultureAdminUI", true, "Core", "en-US" });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_Checkout_CreatedById",
                table: "Checkouts_Checkout",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_Checkout_CustomerId",
                table: "Checkouts_Checkout",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_CheckoutItem_CheckoutId",
                table: "Checkouts_CheckoutItem",
                column: "CheckoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_CheckoutItem_ProductId",
                table: "Checkouts_CheckoutItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkouts_CheckoutItem");

            migrationBuilder.DropTable(
                name: "Checkouts_Checkout");

            migrationBuilder.DeleteData(
                table: "Core_AppSetting",
                keyColumn: "Id",
                keyValue: "Global.DefaultCultureAdminUI");
        }
    }
}
