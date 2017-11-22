using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class RefactoredShipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipping_ShipmentItem");

            migrationBuilder.DropTable(
                name: "Shipping_Shipment");

            migrationBuilder.CreateTable(
                name: "Shipments_Shipment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments_Shipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Shipment_Orders_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipments_ShipmentItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShipmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments_ShipmentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_ShipmentItem_Shipments_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments_Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_Shipment_OrderId",
                table: "Shipments_Shipment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentItem_ShipmentId",
                table: "Shipments_ShipmentItem",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipments_ShipmentItem");

            migrationBuilder.DropTable(
                name: "Shipments_Shipment");

            migrationBuilder.CreateTable(
                name: "Shipping_Shipment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    TrackingNumber = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_Shipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_ShipmentItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderItemId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ShipmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_ShipmentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipping_ShipmentItem_Shipping_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipping_Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_ShipmentItem_ShipmentId",
                table: "Shipping_ShipmentItem",
                column: "ShipmentId");
        }
    }
}
