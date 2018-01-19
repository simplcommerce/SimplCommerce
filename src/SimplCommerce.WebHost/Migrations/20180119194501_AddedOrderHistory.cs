using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedOrderHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders_OrderHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    NewStatus = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    OldStatus = table.Column<int>(nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    OrderSnapshot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_OrderHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderHistory_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderHistory_Orders_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderHistory_CreatedById",
                table: "Orders_OrderHistory",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderHistory_OrderId",
                table: "Orders_OrderHistory",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders_OrderHistory");
        }
    }
}
