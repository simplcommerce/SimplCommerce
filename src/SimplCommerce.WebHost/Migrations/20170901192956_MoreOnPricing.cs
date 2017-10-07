using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class MoreOnPricing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CartItem_Core_User_UserId",
                table: "Orders_CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartItem_UserId",
                table: "Orders_CartItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Pricing_CouponUsage");

            migrationBuilder.DropColumn(
                name: "ExpirationOn",
                table: "Pricing_Coupon");

            migrationBuilder.DropColumn(
                name: "UsageLimit",
                table: "Pricing_Coupon");

            migrationBuilder.DropColumn(
                name: "UsageLimitPerCustomer",
                table: "Pricing_Coupon");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders_CartItem");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxDiscountAmount",
                table: "Pricing_CatalogRule",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "UsageLimitPerCustomer",
                table: "Pricing_CartRule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UsageLimitPerCoupon",
                table: "Pricing_CartRule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxDiscountAmount",
                table: "Pricing_CartRule",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "DiscountStep",
                table: "Pricing_CartRule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CouponCode",
                table: "Orders_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CouponRuleName",
                table: "Orders_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Orders_Order",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotalWithDiscount",
                table: "Orders_Order",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "CartId",
                table: "Orders_CartItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Orders_Cart",
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
                    table.PrimaryKey("PK_Orders_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cart_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_CartId",
                table: "Orders_CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Cart_UserId",
                table: "Orders_Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartItem_Orders_Cart_CartId",
                table: "Orders_CartItem",
                column: "CartId",
                principalTable: "Orders_Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CartItem_Orders_Cart_CartId",
                table: "Orders_CartItem");

            migrationBuilder.DropTable(
                name: "Orders_Cart");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartItem_CartId",
                table: "Orders_CartItem");

            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "CouponRuleName",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "SubTotalWithDiscount",
                table: "Orders_Order");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Orders_CartItem");

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "Pricing_CouponUsage",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpirationOn",
                table: "Pricing_Coupon",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsageLimit",
                table: "Pricing_Coupon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsageLimitPerCustomer",
                table: "Pricing_Coupon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxDiscountAmount",
                table: "Pricing_CatalogRule",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsageLimitPerCustomer",
                table: "Pricing_CartRule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsageLimitPerCoupon",
                table: "Pricing_CartRule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxDiscountAmount",
                table: "Pricing_CartRule",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountStep",
                table: "Pricing_CartRule",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Orders_CartItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_UserId",
                table: "Orders_CartItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CartItem_Core_User_UserId",
                table: "Orders_CartItem",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
