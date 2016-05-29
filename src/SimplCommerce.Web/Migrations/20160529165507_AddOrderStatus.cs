using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using SimplCommerce.Orders.Domain.Models;

namespace SimplCommerce.Web.Migrations
{
    public partial class AddOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders_Order",
                nullable: false,
                defaultValue: OrderStatus.Pending);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders_Order");
        }
    }
}
