using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class Add_Recently_Viewed_Widget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Core_Widget",
                columns: new[] { "Id", "CreateUrl", "CreatedOn", "EditUrl", "IsPublished", "Name", "ViewComponentName" },
                values: new object[] { "RecentlyViewedWidget", "widget-recently-viewed-create", new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 164, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "widget-recently-viewed-edit", false, "Recently Viewed Widget", "RecentlyViewedWidget" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Core_Widget",
                keyColumn: "Id",
                keyValue: "RecentlyViewedWidget");
        }
    }
}