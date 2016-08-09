using System.Collections.Generic;
using System.Linq;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class CartViewModel
    {
        public IList<CartListItem> CartItems { get; set; }

        public string SubTotal => CartItems.Sum(x => x.Total).ToString("C");
    }
}
