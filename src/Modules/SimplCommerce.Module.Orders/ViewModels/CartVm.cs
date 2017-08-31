using System.Collections.Generic;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class CartVm
    {
        public long Id { get; set; }

        public string CouponCode { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotalWithDiscount
        {
            get { return SubTotal - Discount; }
        }

        public IList<CartItemVm> Items { get; set; } = new List<CartItemVm>();
    }
}
