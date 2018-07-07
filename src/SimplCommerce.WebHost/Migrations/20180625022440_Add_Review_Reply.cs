using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class Add_Review_Reply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews_Reply",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ReplierName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews_Reply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Reply_Reviews_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews_Review",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Reply_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Reply_ReviewId",
                table: "Reviews_Reply",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Reply_UserId",
                table: "Reviews_Reply",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews_Reply");
        }
    }
}
