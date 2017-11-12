using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Shipping.ViewModels
{
    public class ShippingAddressVmAjax
    {
        public int CountryId { get; set; }

        public int StateOrProvinceId { get; set; }

        public string AddressLine1 { get; set; }

        public string OrderAmount { get; set; }
    }

}
