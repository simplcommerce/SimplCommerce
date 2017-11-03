using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Orders.PayViewModels
{
    public class PaymentVm
    {
        public string intent { get; set; }
        public PaymentLinks redirect_urls { get; set; }
        public Payer payer { get; set; }
        public IEnumerable<Transaction> transactions { get; set; }
    }
}
