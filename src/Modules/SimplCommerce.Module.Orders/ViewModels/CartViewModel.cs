using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class CartViewModel
    {
        public IList<CartListItem> CartItems { get; set; }

        public string SubTotal
            => string.Concat(CartItems.Sum(x => x.Total).ToString("N0", new CultureInfo("vi-VN")), " VND");
    }
}
