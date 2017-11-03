using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Orders.PayViewModels
{
    public class PaymentLinks
    {
        public string return_url { get; set; }
        public string cancel_url { get; set; }
    }
}
