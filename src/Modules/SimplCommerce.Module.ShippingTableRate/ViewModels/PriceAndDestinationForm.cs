using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.ShippingTableRate.ViewModels
{
    public class PriceAndDestinationForm
    {
        public long Id { get; set; }

        public long? CountryId { get; set; }

        public string CountryName { get; set; }

        public long? StateOrProvinceId { get; set; }

        public string StateOrProvinceName { get; set; }

        public string Note { get; set; }

        public decimal MinOrderSubtotal { get; set; }

        public decimal ShippingPrice { get; set; }
    }
}
