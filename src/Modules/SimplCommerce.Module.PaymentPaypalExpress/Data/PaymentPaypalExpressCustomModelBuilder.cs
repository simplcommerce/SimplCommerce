using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentPaypalExpress.Data
{
    public class PaymentPaypalExpressCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("PaypalExpress") { Name = "Paypal Express", LandingViewComponentName = "PaypalExpressLanding", ConfigureUrl = "payments-paypalExpress-config", IsEnabled = true, AdditionalSettings = "{ \"IsSandbox\":true, \"ClientId\":\"\", \"ClientSecret\":\"\" }" }
            );
        }
    }
}
