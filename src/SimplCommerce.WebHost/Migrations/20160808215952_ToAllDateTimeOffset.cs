using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class ToAllDateTimeOffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Orders_Order",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Orders_Order",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Orders_CartItem",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Core_WidgetInstance",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Core_WidgetInstance",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Core_Widget",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUsedOn",
                table: "Core_UserAddress",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Core_User",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Core_User",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Cms_Page",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "PublishedOn",
                table: "Cms_Page",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Cms_Page",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Catalog_Product",
                nullable: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "PublishedOn",
                table: "Catalog_Product",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Catalog_Product",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Orders_Order",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders_Order",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders_CartItem",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Core_WidgetInstance",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Core_WidgetInstance",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Core_Widget",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUsedOn",
                table: "Core_UserAddress",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Core_User",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Core_User",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Cms_Page",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Cms_Page",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cms_Page",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Catalog_Product",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Catalog_Product",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Catalog_Product",
                nullable: false);
        }
    }
}
