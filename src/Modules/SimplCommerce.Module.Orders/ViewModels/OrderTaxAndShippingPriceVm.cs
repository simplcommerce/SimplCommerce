using System.Collections.Generic;
using SimplCommerce.Module.ShippingPrices.Services;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class OrderTaxAndShippingPriceVm
    {
        public decimal TaxAmount { get; set; }

        public bool IsProductPriceIncludedTax { get; set; }

        public IList<ShippingPrice> ShippingPrices { get; set; }
    }
}
