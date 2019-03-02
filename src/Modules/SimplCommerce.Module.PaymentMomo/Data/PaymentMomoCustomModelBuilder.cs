using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentMomo.Data
{
    public class PaymentMomoCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("MomoPayment") { Name = "Momo Payment", LandingViewComponentName = "MomoLanding", ConfigureUrl = "payments-momo-config", IsEnabled = true, AdditionalSettings = null }
            );
        }
    }
}
