using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class Paymenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Confirmation = table.Column<bool>(type: "bit", nullable: false),
                    Min = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeDec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percent = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    paymenttypep = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentType");
        }
    }
}
