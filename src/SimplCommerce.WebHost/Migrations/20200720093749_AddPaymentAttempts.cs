using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddPaymentAttempts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments_PaymentAttempt",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LatestUpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    CartId = table.Column<long>(nullable: false),
                    PaymentProviderId = table.Column<string>(nullable: true),
                    PaymentAttemptId = table.Column<string>(nullable: true),
                    Environment = table.Column<string>(nullable: true),
                    RequestedAmount = table.Column<decimal>(nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    IsProcessed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments_PaymentAttempt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentAttempt_ShoppingCart_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "ShoppingCart_Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentAttempt_Payments_PaymentProvider_PaymentProviderId",
                        column: x => x.PaymentProviderId,
                        principalTable: "Payments_PaymentProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Payments_PaymentProvider",
                columns: new[] { "Id", "AdditionalSettings", "ConfigureUrl", "IsEnabled", "LandingViewComponentName", "Name" },
                values: new object[] { "StripeV2", "{\"PublicKey\": \"pk_test_6pRNASCoBOKtIshFeQd4XMUh\", \"PrivateKey\" : \"sk_test_BQokikJOvBiI2HlWgH4olfQ2\"}", "payments-stripev2-config", true, "StripeV2Landing", "Stripe V2" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentAttempt_CartId",
                table: "Payments_PaymentAttempt",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentAttempt_PaymentProviderId",
                table: "Payments_PaymentAttempt",
                column: "PaymentProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments_PaymentAttempt");

            migrationBuilder.DeleteData(
                table: "Payments_PaymentProvider",
                keyColumn: "Id",
                keyValue: "StripeV2");
        }
    }
}
