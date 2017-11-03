using SimplCommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.Shipping.Data
{
    public class ShippingCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingMethod>(b =>
            {

                b.ToTable("ShippingMethod");
            });
        }
    }
}
