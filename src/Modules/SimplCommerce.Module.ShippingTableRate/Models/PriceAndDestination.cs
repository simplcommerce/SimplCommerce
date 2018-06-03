using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.ShippingTableRate.Models
{
    public class PriceAndDestination : EntityBase
    {
        public Country Country { get; set; }

        public string CountryId { get; set; }

        public StateOrProvince StateOrProvince { get; set; }

        public long? StateOrProvinceId { get; set; }

        public District District { get; set; }

        public long? DistrictId { get; set; }

        public string ZipCode { get; set; }

        public string Note { get; set; }

        public decimal MinOrderSubtotal { get; set; }

        public decimal ShippingPrice { get; set; }
    }
}
