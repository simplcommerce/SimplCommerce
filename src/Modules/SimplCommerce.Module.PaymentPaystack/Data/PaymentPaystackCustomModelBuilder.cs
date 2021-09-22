using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentPaystack.Data
{
    public class PaymentPaystackCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("Paystack") { Name = "Paystack", LandingViewComponentName = "PaystackLanding", ConfigureUrl = "payments-paystack-config", IsEnabled = true, AdditionalSettings = "{ \"ClientSecret\":\"\" }" }
            );
        }
    }
}
