using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class paymentisoptionalinorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Payment_p");

            //migrationBuilder.AlterColumn<long>(
            //    name: "Paymentp_Id",
            //    table: "Orders_Order",
            //    type: "bigint",
            //    nullable: true,
            //    oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "OurPayments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    Istended = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    PayReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayedMethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OurPayments_Orders_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OurPayments_OrderId",
                table: "OurPayments",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurPayments");

            migrationBuilder.AlterColumn<long>(
                name: "Paymentp_Id",
                table: "Orders_Order",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Payment_p",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPayed = table.Column<bool>(nullable: false),
                    Istended = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: true),
                    PayReferenceId = table.Column<string>(nullable: true),
                    PayedMethodName = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<string>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_p", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_p_Orders_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_p_OrderId",
                table: "Payment_p",
                column: "OrderId");
        }
    }
}
