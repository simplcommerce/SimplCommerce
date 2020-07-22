using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentStripeV2.Data
{
    public class PaymentStripeV2CustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("StripeV2") { Name = "Stripe V2", LandingViewComponentName = "StripeV2Landing", ConfigureUrl = "payments-stripev2-config", IsEnabled = true, AdditionalSettings = "{\"PublicKey\": \"pk_test_6pRNASCoBOKtIshFeQd4XMUh\", \"PrivateKey\" : \"sk_test_BQokikJOvBiI2HlWgH4olfQ2\"}" }
            );
        }
    }
}
