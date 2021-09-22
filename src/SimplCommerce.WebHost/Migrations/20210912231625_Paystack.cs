using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class Paystack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Core_AppSetting",
                columns: new[] { "Id", "IsVisibleInCommonSettingPage", "Module", "Value" },
                values: new object[] { "Global.DefaultCultureAdminUI", true, "Core", "en-US" });

            migrationBuilder.InsertData(
                table: "Payments_PaymentProvider",
                columns: new[] { "Id", "AdditionalSettings", "ConfigureUrl", "IsEnabled", "LandingViewComponentName", "Name" },
                values: new object[] { "Paystack", "{ \"ClientSecret\":\"\" }", "payments-paystack-config", true, "PaystackLanding", "Paystack" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Core_AppSetting",
                keyColumn: "Id",
                keyValue: "Global.DefaultCultureAdminUI");

            migrationBuilder.DeleteData(
                table: "Payments_PaymentProvider",
                keyColumn: "Id",
                keyValue: "Paystack");
        }
    }
}
