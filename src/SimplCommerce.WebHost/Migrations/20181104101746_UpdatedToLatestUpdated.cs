using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class UpdatedToLatestUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_User_UpdatedById",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_Page_Core_User_UpdatedById",
                table: "Cms_Page");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItem_Core_User_UpdatedById",
                table: "News_NewsItem");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Payments_Payment");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "WishList_WishListItem",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "WishList_WishList",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Shipments_Shipment",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Orders_Order",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "News_NewsItem",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "News_NewsItem",
                newName: "LatestUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_News_NewsItem_UpdatedById",
                table: "News_NewsItem",
                newName: "IX_News_NewsItem_LatestUpdatedById");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Core_WidgetInstance",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Core_Vendor",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Core_User",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Core_CustomerGroup",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Cms_Page",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "Cms_Page",
                newName: "LatestUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Cms_Page_UpdatedById",
                table: "Cms_Page",
                newName: "IX_Cms_Page_LatestUpdatedById");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Catalog_Product",
                newName: "LatestUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "Catalog_Product",
                newName: "LatestUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_UpdatedById",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_LatestUpdatedById");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LatestUpdatedOn",
                table: "ShoppingCart_Cart",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LatestUpdatedOn",
                table: "Payments_Payment",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_User_LatestUpdatedById",
                table: "Catalog_Product",
                column: "LatestUpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_Page_Core_User_LatestUpdatedById",
                table: "Cms_Page",
                column: "LatestUpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItem_Core_User_LatestUpdatedById",
                table: "News_NewsItem",
                column: "LatestUpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Product_Core_User_LatestUpdatedById",
                table: "Catalog_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Cms_Page_Core_User_LatestUpdatedById",
                table: "Cms_Page");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsItem_Core_User_LatestUpdatedById",
                table: "News_NewsItem");

            migrationBuilder.DropColumn(
                name: "LatestUpdatedOn",
                table: "ShoppingCart_Cart");

            migrationBuilder.DropColumn(
                name: "LatestUpdatedOn",
                table: "Payments_Payment");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "WishList_WishListItem",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "WishList_WishList",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "Shipments_Shipment",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "Orders_Order",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "News_NewsItem",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedById",
                table: "News_NewsItem",
                newName: "UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_News_NewsItem_LatestUpdatedById",
                table: "News_NewsItem",
                newName: "IX_News_NewsItem_UpdatedById");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "Core_WidgetInstance",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "Core_Vendor",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "Core_User",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "Core_CustomerGroup",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "Cms_Page",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedById",
                table: "Cms_Page",
                newName: "UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Cms_Page_LatestUpdatedById",
                table: "Cms_Page",
                newName: "IX_Cms_Page_UpdatedById");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedOn",
                table: "Catalog_Product",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LatestUpdatedById",
                table: "Catalog_Product",
                newName: "UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_Product_LatestUpdatedById",
                table: "Catalog_Product",
                newName: "IX_Catalog_Product_UpdatedById");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "ShoppingCart_Cart",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedOn",
                table: "Payments_Payment",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Product_Core_User_UpdatedById",
                table: "Catalog_Product",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cms_Page_Core_User_UpdatedById",
                table: "Cms_Page",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsItem_Core_User_UpdatedById",
                table: "News_NewsItem",
                column: "UpdatedById",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
