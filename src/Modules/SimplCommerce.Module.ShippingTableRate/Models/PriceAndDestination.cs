using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.ShippingTableRate.Models
{
    public class PriceAndDestination : EntityBase
    {
        public string Country { get; set; }

        public string StateOrProvince { get; set; }

        public decimal MinOrderSubtotal { get; set; }

        public decimal ShippingPrice { get; set; }
    }
}
