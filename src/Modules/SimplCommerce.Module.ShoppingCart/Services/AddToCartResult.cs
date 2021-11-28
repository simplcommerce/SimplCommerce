using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.ShoppingCart.Services
{
    public class AddToCartResult
    {
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public bool Success { get; set; }
    }
}
