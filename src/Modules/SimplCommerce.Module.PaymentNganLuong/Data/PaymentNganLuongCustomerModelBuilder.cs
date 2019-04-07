using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentNganLuong.Data
{
    public class PaymentNganLuongCustomerModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("NganLuong") { Name = "Ngan Luong Payment", LandingViewComponentName = "NganLuongLanding", ConfigureUrl = "payments-nganluong-config", IsEnabled = true, AdditionalSettings = "{\"IsSandbox\":true, \"MerchantId\": 47249, \"MerchantPassword\": \"e530745693dbde678f9da98a7c821a07\", \"ReceiverEmail\": \"nlqthien@gmail.com\"}" }
            );
        }
    }
}
