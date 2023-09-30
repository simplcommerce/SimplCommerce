using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels
{
    public class TaxAndShippingPriceRequestVm
    {
        public string SelectedShippingMethodName { get; set; }

        public ShippingAddressVm NewShippingAddress { get; set; }

        public ShippingAddressVm NewBillingAddress { get; set; }

        public long ExistingShippingAddressId { get; set; }
    }
}
