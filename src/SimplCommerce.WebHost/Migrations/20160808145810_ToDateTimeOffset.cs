using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class ToDateTimeOffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "PublishStart",
                table: "Core_WidgetInstance",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "PublishEnd",
                table: "Core_WidgetInstance",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishStart",
                table: "Core_WidgetInstance",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishEnd",
                table: "Core_WidgetInstance",
                nullable: true);
        }
    }
}
