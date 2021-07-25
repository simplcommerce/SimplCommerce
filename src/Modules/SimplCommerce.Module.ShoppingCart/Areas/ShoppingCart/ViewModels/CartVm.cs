using System.Collections.Generic;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels
{
    public class CartVm
    {
        private readonly ICurrencyService _currencyService;

        public CartVm(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public long Id { get; set; }

        public bool LockedOnCheckout { get; set; }

        public string CouponCode { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalString => _currencyService.FormatCurrency(SubTotal);

        public decimal Discount { get; set; }

        public string DiscountString => _currencyService.FormatCurrency(Discount);

        public string CouponValidationErrorMessage { get; set; }

        public bool IsProductPriceIncludeTax { get; set; }

        public decimal? TaxAmount { get; set; }

        public string OrderNote { get; set; }

        public string TaxAmountString => TaxAmount.HasValue ? _currencyService.FormatCurrency(TaxAmount.Value) : "-";

        public decimal? ShippingAmount { get; set; }

        public string ShippingAmountString =>
            ShippingAmount.HasValue ? _currencyService.FormatCurrency(ShippingAmount.Value) : "-";

        public decimal SubTotalWithDiscount => SubTotal - Discount;

        public decimal SubTotalWithDiscountWithoutTax
        {
            get
            {
                if (IsProductPriceIncludeTax)
                {
                    return SubTotalWithDiscount - TaxAmount ?? 0;
                }

                return SubTotalWithDiscount;
            }
        }

        public decimal OrderTotal
        {
            get
            {
                if (IsProductPriceIncludeTax)
                {
                    return SubTotal + (ShippingAmount ?? 0) - Discount;
                }

                return SubTotal + (TaxAmount ?? 0) + (ShippingAmount ?? 0) - Discount;
            }
        }

        public string OrderTotalString => _currencyService.FormatCurrency(OrderTotal);

        public IList<CartItemVm> Items { get; set; } = new List<CartItemVm>();

        public bool IsValid
        {
            get
            {
                foreach (var item in Items)
                {
                    if (!item.IsProductAvailabeToOrder)
                    {
                        return false;
                    }

                    if (item.ProductStockTrackingIsEnabled && item.ProductStockQuantity < item.Quantity)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
