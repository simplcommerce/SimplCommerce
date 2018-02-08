using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class RemoveCouponUsage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pricing_CouponUsage");

            migrationBuilder.RenameColumn(
                name: "UsedOn",
                table: "Pricing_CartRuleUsage",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<long>(
                name: "CouponId",
                table: "Pricing_CartRuleUsage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CartRuleUsage_CouponId",
                table: "Pricing_CartRuleUsage",
                column: "CouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleUsage_Pricing_Coupon_CouponId",
                table: "Pricing_CartRuleUsage",
                column: "CouponId",
                principalTable: "Pricing_Coupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleUsage_Pricing_Coupon_CouponId",
                table: "Pricing_CartRuleUsage");

            migrationBuilder.DropIndex(
                name: "IX_Pricing_CartRuleUsage_CouponId",
                table: "Pricing_CartRuleUsage");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "Pricing_CartRuleUsage");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Pricing_CartRuleUsage",
                newName: "UsedOn");

            migrationBuilder.CreateTable(
                name: "Pricing_CouponUsage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CouponId = table.Column<long>(nullable: false),
                    UsedOn = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing_CouponUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricing_CouponUsage_Pricing_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Pricing_Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pricing_CouponUsage_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CouponUsage_CouponId",
                table: "Pricing_CouponUsage",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_CouponUsage_UserId",
                table: "Pricing_CouponUsage",
                column: "UserId");
        }
    }
}
