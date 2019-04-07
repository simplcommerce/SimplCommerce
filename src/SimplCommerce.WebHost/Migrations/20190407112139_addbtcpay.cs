using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class addbtcpay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payments_PaymentProvider",
                columns: new[] { "Id", "AdditionalSettings", "ConfigureUrl", "IsEnabled", "LandingViewComponentName", "Name" },
                values: new object[] { "BtcPayServer", @"{
  ""Server"": ""https://btcpayjungle.com"",
  ""Seed"": null
}", "payments-btcpayserver-config", true, "BtcPayLanding", "BtcPayServer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments_PaymentProvider",
                keyColumn: "Id",
                keyValue: "BtcPayServer");
        }
    }
}
