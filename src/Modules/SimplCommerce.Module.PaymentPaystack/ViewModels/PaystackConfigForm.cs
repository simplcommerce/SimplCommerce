using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentPaystack.ViewModels
{
    public class PaystackConfigForm
    {

        public string ClientSecret { get; set; }

        public decimal PaymentFee { get; set; }
    }
}
