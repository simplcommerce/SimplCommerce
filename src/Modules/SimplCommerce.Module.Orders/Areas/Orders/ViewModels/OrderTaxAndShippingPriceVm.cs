using System.Collections.Generic;
using SimplCommerce.Module.ShippingPrices.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;

namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderTaxAndShippingPriceVm
    {
        public bool IsProductPriceIncludedTax { get; set; }

        public IList<ShippingPrice> ShippingPrices { get; set; }

        public string SelectedShippingMethodName { get; set; }

        public CartVm Cart { get; set; }
    }
}
