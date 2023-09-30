using SimplCommerce.Module.Core.Services;
using System.Collections.Generic;

namespace SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels
{
    public class CartVm
    {
        private readonly ICurrencyService _currencyService;

        public CartVm(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public string CouponCode { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalString { get { return _currencyService.FormatCurrency(SubTotal); } }

        public decimal Discount { get; set; }

        public string DiscountString { get { return _currencyService.FormatCurrency(Discount); } }

        public string CouponValidationErrorMessage { get; set; }

        public decimal SubTotalWithDiscount
        {
            get
            {
                return SubTotal - Discount;
            }
        }

        public string SubTotalWithDiscountString { get { return _currencyService.FormatCurrency(SubTotalWithDiscount); } }

        public IList<CartItemVm> Items { get; set; } = new List<CartItemVm>();

        public bool IsValid
        {
            get
            {
                foreach(var item in Items)
                {
                    if (!item.IsProductAvailabeToOrder)
                    {
                        return false;
                    }

                    if(item.ProductStockTrackingIsEnabled && item.ProductStockQuantity < item.Quantity)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
