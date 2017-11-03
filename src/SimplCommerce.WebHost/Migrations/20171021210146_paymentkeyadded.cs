using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class paymentkeyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Paymentp_Id",
            //    table: "Orders_Order");

            migrationBuilder.AddColumn<long>(
                name: "PaymentId",
                table: "Orders_Order",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders_Order");

            migrationBuilder.AddColumn<long>(
                name: "Paymentp_Id",
                table: "Orders_Order",
                nullable: true);
        }
    }
}
