using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class CartRuleSetDeleteCascase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                table: "Pricing_Coupon");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCategory",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCustomerGroup",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleProduct",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                table: "Pricing_Coupon",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                table: "Pricing_Coupon");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCategory",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleCustomerGroup",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId",
                table: "Pricing_CartRuleProduct",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId",
                table: "Pricing_Coupon",
                column: "CartRuleId",
                principalTable: "Pricing_CartRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
