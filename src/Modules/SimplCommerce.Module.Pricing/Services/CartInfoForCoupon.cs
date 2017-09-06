using System.Collections.Generic;

namespace SimplCommerce.Module.Pricing.Services
{
    public class CartInfoForCoupon
    {
        public IList<CartItemForCoupon> Items { get; set; } = new List<CartItemForCoupon>();
    }
}
