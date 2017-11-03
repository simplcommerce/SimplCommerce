using SimplCommerce.Module.Shipping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Shipping.Services
{
    public interface IShippingService
    {
        decimal Calculate(long id, decimal total);
        ShippingMethod Find(long id);
    }
}
