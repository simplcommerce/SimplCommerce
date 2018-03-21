using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentCoD.Models
{
    public class CODfee
    {
        public bool CartTotalMinValue { get; set; }
        public bool CartTotalMaxValue { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public decimal PaymentFee { get; set; }
    }
}
