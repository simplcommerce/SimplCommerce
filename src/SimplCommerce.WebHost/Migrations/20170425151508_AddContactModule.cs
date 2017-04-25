using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddContactModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource");

            migrationBuilder.AlterColumn<long>(
                name: "CultureId",
                table: "Localization_Resource",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Contact_ContactCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_ContactCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact_Contact",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Contact_Contact_ContactCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Contact_ContactCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_Contact_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_Contact_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Contact_CategoryId",
                table: "Contact_Contact",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Contact_CreatedById",
                table: "Contact_Contact",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Contact_UpdatedById",
                table: "Contact_Contact",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource",
                column: "CultureId",
                principalTable: "Localization_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource");

            migrationBuilder.DropTable(
                name: "Contact_Contact");

            migrationBuilder.DropTable(
                name: "Contact_ContactCategory");

            migrationBuilder.AlterColumn<long>(
                name: "CultureId",
                table: "Localization_Resource",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_Resource_Localization_Culture_CultureId",
                table: "Localization_Resource",
                column: "CultureId",
                principalTable: "Localization_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
