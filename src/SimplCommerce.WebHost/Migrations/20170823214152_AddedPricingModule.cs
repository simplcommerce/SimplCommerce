using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedPricingModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pricing_CartRule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DiscountStep = table.Column<int>(type: "int", nullable: false),
                    EndOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCouponRequired = table.Column<bool>(type: "bit", nullable: false),
                    MaxDiscountAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuleToApply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UsageLimitPerCoupon = table.Column<int>(type: "int", nullable: false),
                    UsageLimitPerCustomer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CartRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pricing_CatalogRule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EndOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaxDiscountAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuleToApply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CatalogRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pricing_CartRuleUsage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartRuleId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    UsedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CartRuleUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricing_CartRuleUsage_Pricing_CartRule_CartRuleId",
                        column: x => x.CartRuleId,
                        principalTable: "Pricing_CartRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pricing_CartRuleUsage_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pricing_Coupon",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartRuleId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpirationOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UsageLimit = table.Column<int>(type: "int", nullable: false),
                    UsageLimitPerCustomer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_Coupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                        column: x => x.CartRuleId,
                        principalTable: "Pricing_CartRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pricing_CatalogRuleCustomerGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartRuleId = table.Column<long>(type: "bigint", nullable: true),
                    CatalogRuleId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerGroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CatalogRuleCustomerGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                        column: x => x.CartRuleId,
                        principalTable: "Pricing_CartRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CatalogRule_CatalogRuleId",
                        column: x => x.CatalogRuleId,
                        principalTable: "Pricing_CatalogRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pricing_CatalogRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "Core_CustomerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pricing_CouponUsage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CouponId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    UsedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CouponUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricing_CouponUsage_Pricing_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Pricing_Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pricing_CouponUsage_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CartRuleUsage_CartRuleId",
                table: "Pricing_CartRuleUsage",
                column: "CartRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CartRuleUsage_UserId",
                table: "Pricing_CartRuleUsage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CatalogRuleCustomerGroup_CartRuleId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CartRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CatalogRuleCustomerGroup_CatalogRuleId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CatalogRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CatalogRuleCustomerGroup_CustomerGroupId",
                table: "Pricing_CatalogRuleCustomerGroup",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_Coupon_CartRuleId",
                table: "Pricing_Coupon",
                column: "CartRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CouponUsage_CouponId",
                table: "Pricing_CouponUsage",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CouponUsage_UserId",
                table: "Pricing_CouponUsage",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pricing_CartRuleUsage");

            migrationBuilder.DropTable(
                name: "Pricing_CatalogRuleCustomerGroup");

            migrationBuilder.DropTable(
                name: "Pricing_CouponUsage");

            migrationBuilder.DropTable(
                name: "Pricing_CatalogRule");

            migrationBuilder.DropTable(
                name: "Pricing_Coupon");

            migrationBuilder.DropTable(
                name: "Pricing_CartRule");
        }
    }
}
