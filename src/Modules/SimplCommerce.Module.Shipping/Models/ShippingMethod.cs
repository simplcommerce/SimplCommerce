using SimplCommerce.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Shipping.Models
{
    public class ShippingMethod : EntityBase
    {
        public string Name { get; set; }
        public string Dec { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal PerKg { get; set; }
        public string Note { get; set; }

    }
}
