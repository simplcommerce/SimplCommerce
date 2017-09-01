using System.Collections.Generic;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class CartVm
    {
        public long Id { get; set; }

        public string CouponCode { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalString { get { return SubTotal.ToString("C"); } }

        public decimal Discount { get; set; }

        public string DiscountString { get { return Discount.ToString("C"); } }

        public decimal SubTotalWithDiscount
        {
            get { return SubTotal - Discount; }
        }

        public string SubTotalWithDiscountString { get { return SubTotalWithDiscount.ToString("C"); } }

        public IList<CartItemVm> Items { get; set; } = new List<CartItemVm>();
    }
}
