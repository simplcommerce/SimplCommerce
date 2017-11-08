using System.Collections.Generic;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.Shipping.Services
{
    public class GetShippingPriceRequest
    {
        public Address ShippingAddress { get; set; }

        public Address WarehouseAddress { get; set; }

        public IList<ShippingItem> ShippingItem { get; set; } = new List<ShippingItem>();

        public decimal OrderAmount { get; set; }
    }
}
