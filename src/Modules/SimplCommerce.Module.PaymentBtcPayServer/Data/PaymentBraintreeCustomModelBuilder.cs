using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentBtcPayServer.Models;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentBtcPayServer.Data
{
    public class PaymentBtcPayServerCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("BtcPayServer") {
                    Name = PaymentProviderConstants.BtcPayServerProviderId,
                    LandingViewComponentName = "BtcPayLanding",
                    ConfigureUrl = "payments-btcpayserver-config",
                    IsEnabled = true,
                    AdditionalSettings = JObject.FromObject(new BtcPayServerConfig()
                        {
                            Server = new Uri("https://btcpayjungle.com")
                        }).ToString()
                    
                }
            );
        }
    }
}
