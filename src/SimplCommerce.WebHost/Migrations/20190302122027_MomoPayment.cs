using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class MomoPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payments_PaymentProvider",
                columns: new[] { "Id", "AdditionalSettings", "ConfigureUrl", "IsEnabled", "LandingViewComponentName", "Name" },
                values: new object[] { "MomoPayment", "{\"IsSandbox\":true,\"PartnerCode\":\"MOMOIQA420180417\",\"AccessKey\":\"SvDmj2cOTYZmQQ3H\",\"SecretKey\":\"PPuDXq1KowPT1ftR8DvlQTHhC03aul17\",\"PaymentFee\":0.0}", "payments-momo-config", true, "MomoLanding", "Momo Payment" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments_PaymentProvider",
                keyColumn: "Id",
                keyValue: "MomoPayment");
        }
    }
}
