using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddedShippingInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory_Stock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Warehouse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Warehouse_Core_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Core_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_Shipment",
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
                    table.PrimaryKey("PK_Shipping_Shipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_ShippingProvider",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlyCountryIdsString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlyStateOrProvinceIdsString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingPriceServiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToAllShippingEnabledCountries = table.Column<bool>(type: "bit", nullable: false),
                    ToAllShippingEnabledStatesOrProvinces = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_ShippingProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingTableRate_PriceAndDestination",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOrderSubtotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ShippingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StateOrProvince = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingTableRate_PriceAndDestination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_ShipmentItem",
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
                    table.PrimaryKey("PK_Shipping_ShipmentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipping_ShipmentItem_Shipping_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipping_Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Warehouse_AddressId",
                table: "Inventory_Warehouse",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_ShipmentItem_ShipmentId",
                table: "Shipping_ShipmentItem",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory_Stock");

            migrationBuilder.DropTable(
                name: "Inventory_Warehouse");

            migrationBuilder.DropTable(
                name: "Shipping_ShipmentItem");

            migrationBuilder.DropTable(
                name: "Shipping_ShippingProvider");

            migrationBuilder.DropTable(
                name: "ShippingTableRate_PriceAndDestination");

            migrationBuilder.DropTable(
                name: "Shipping_Shipment");
        }
    }
}
