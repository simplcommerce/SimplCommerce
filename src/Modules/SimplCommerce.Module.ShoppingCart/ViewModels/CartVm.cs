using System.Collections.Generic;

namespace SimplCommerce.Module.ShoppingCart.ViewModels
{
    public class CartVm
    {
        public long Id { get; set; }

        public string CouponCode { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalString { get { return SubTotal.ToString("C"); } }

        public decimal Discount { get; set; }

        public string DiscountString { get { return Discount.ToString("C"); } }

        public string CouponValidationErrorMessage { get; set; }

        public bool IsProductPriceIncludeTax { get; set; }

        public decimal? TaxAmount { get; set; }

        public string TaxAmountString
        {
            get
            {
                return TaxAmount.HasValue ? TaxAmount.Value.ToString("C") : "-";
            }
        }

        public decimal? ShippingAmount { get; set; }

        public string ShippingAmountString
        {
            get { return ShippingAmount.HasValue ? ShippingAmount.Value.ToString("C") : "-"; }
        }

        public decimal SubTotalWithDiscount
        {
            get
            {
                return SubTotal - Discount;
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

        public string OrderTotalString { get { return OrderTotal.ToString("C"); } }

        public IList<CartItemVm> Items { get; set; } = new List<CartItemVm>();
    }
}
