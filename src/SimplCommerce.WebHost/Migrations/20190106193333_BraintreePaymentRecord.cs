using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class BraintreePaymentRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payments_PaymentProvider",
                columns: new[] { "Id", "AdditionalSettings", "ConfigureUrl", "IsEnabled", "LandingViewComponentName", "Name" },
                values: new object[] { "Braintree", "{\"PublicKey\": \"6j4d7qspt5n48kx4\", \"PrivateKey\" : \"bd1c26e53a6d811243fcc3eb268113e1\", \"MerchantId\" : \"ncsh7wwqvzs3cx9q\", \"IsProduction\" : \"false\"}", "payments-braintree-config", true, "BraintreeLanding", "Braintree" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments_PaymentProvider",
                keyColumn: "Id",
                keyValue: "Braintree");
        }
    }
}
