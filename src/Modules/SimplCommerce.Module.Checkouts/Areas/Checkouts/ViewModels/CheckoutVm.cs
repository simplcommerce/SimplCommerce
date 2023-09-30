using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels
{
    public class CheckoutVm
    {
        private readonly ICurrencyService _currencyService;

        public CheckoutVm(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public Guid Id { get; set; }

        public bool LockedOnCheckout { get; set; }

        public string CouponCode { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalString { get { return _currencyService.FormatCurrency(SubTotal); } }

        public decimal Discount { get; set; }

        public string DiscountString { get { return _currencyService.FormatCurrency(Discount); } }

        public string CouponValidationErrorMessage { get; set; }

        public bool IsProductPriceIncludeTax { get; set; }

        public decimal? TaxAmount { get; set; }

        public string OrderNote { get; set; }

        public string TaxAmountString
        {
            get
            {
                return TaxAmount.HasValue ? _currencyService.FormatCurrency(TaxAmount.Value) : "-";
            }
        }

        public decimal? ShippingAmount { get; set; }

        public string ShippingAmountString
        {
            get { return ShippingAmount.HasValue ? _currencyService.FormatCurrency(ShippingAmount.Value) : "-"; }
        }

        public decimal SubTotalWithDiscount
        {
            get
            {
                return SubTotal - Discount;
            }
        }

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

        public string OrderTotalString { get { return _currencyService.FormatCurrency(OrderTotal); } }

        public IList<CheckoutItemVm> Items { get; set; } = new List<CheckoutItemVm>();

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
