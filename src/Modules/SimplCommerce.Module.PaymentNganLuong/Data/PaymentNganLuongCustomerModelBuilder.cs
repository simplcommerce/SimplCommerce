using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentNganLuong.Data
{
    public class PaymentNganLuongCustomerModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("NganLuong") { Name = "Ngan Luong Payment", LandingViewComponentName = "NganLuongLanding", ConfigureUrl = "payments-nganluong-config", IsEnabled = true, AdditionalSettings = "{\"IsSandbox\":true,\"PartnerCode\":\"MOMOIQA420180417\",\"AccessKey\":\"SvDmj2cOTYZmQQ3H\",\"SecretKey\":\"PPuDXq1KowPT1ftR8DvlQTHhC03aul17\",\"PaymentFee\":0.0}" }
            );
        }
    }
}
