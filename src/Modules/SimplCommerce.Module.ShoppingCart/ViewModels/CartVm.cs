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

        public bool IsTaxIncludedInProductPrice { get; set; }

        public decimal OrderTotal
        {
            get { return SubTotal - Discount; }
        }

        public string OrderTotalString { get { return OrderTotal.ToString("C"); } }

        public IList<CartItemVm> Items { get; set; } = new List<CartItemVm>();
    }
}
