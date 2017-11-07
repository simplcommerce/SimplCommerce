using System;
using System.Threading.Tasks;
using SimplCommerce.Module.Shipping.Models;
using SimplCommerce.Module.Shipping.Services;

namespace SimplCommerce.Module.ShippingTableRate.Services
{
    public class TableRateShippingService : IShippingRateService
    {
        public Task<GetShippingRateResponse> GetShippingRates(GetShippingRateRequest request, ShippingProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
