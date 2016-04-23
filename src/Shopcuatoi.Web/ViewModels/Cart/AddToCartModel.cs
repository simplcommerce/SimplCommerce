using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopcuatoi.Web.ViewModels.Cart
{
    public class AddToCartModel
    {
        public long ProductId { get; set; }

        public string VariationName { get; set; }

        public int Quantity { get; set; }
    }
}
