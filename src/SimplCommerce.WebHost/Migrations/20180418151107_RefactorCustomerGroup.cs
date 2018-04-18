using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class RefactorCustomerGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Core_UserCustomerGroup");

            migrationBuilder.CreateTable(
                name: "Core_CustomerGroupUser",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    CustomerGroupId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_CustomerGroupUser", x => new { x.UserId, x.CustomerGroupId });
                    table.ForeignKey(
                        name: "FK_Core_CustomerGroupUser_Core_CustomerGroup_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "Core_CustomerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_CustomerGroupUser_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Core_CustomerGroupUser_CustomerGroupId",
                table: "Core_CustomerGroupUser",
                column: "CustomerGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Core_CustomerGroupUser");

            migrationBuilder.CreateTable(
                name: "Core_UserCustomerGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerGroupId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserCustomerGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_UserCustomerGroup_Core_CustomerGroup_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "Core_CustomerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_UserCustomerGroup_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserCustomerGroup_CustomerGroupId",
                table: "Core_UserCustomerGroup",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserCustomerGroup_UserId",
                table: "Core_UserCustomerGroup",
                column: "UserId");
        }
    }
}
