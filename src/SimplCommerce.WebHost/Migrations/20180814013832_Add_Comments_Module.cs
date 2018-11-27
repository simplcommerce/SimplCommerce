using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class Add_Comments_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments_Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    CommentText = table.Column<string>(nullable: true),
                    CommenterName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    EntityTypeId = table.Column<string>(nullable: true),
                    EntityId = table.Column<long>(nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comment_Comments_Comment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments_Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comment_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Core_AppSetting",
                columns: new[] { "Id", "IsVisibleInCommonSettingPage", "Module", "Value" },
                values: new object[] { "Catalog.IsCommentsRequireApproval", true, "Catalog", "true" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Comment_ParentId",
                table: "Comments_Comment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Comment_UserId",
                table: "Comments_Comment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments_Comment");

            migrationBuilder.DeleteData(
                table: "Core_AppSetting",
                keyColumn: "Id",
                keyValue: "Catalog.IsCommentsRequireApproval");
        }
    }
}
