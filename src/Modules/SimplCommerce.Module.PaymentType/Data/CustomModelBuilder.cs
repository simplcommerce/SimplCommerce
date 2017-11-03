using SimplCommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Module.PaymentType.Data
{
    public class CustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentType.Models.PaymentType>(b =>
            {
               
                b.ToTable("PaymentType");
            });
        }
    }
}
