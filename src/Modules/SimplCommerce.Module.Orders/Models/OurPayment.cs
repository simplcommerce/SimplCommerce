using SimplCommerce.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Orders.Models
{
    public class OurPayment : EntityBase
    {
        public string PaymentDate { get; set; }
        public bool IsPayed { get; set; }
        public int Istended { get; set; }
        public string PayReferenceId { get; set; }

        public int PaymentTypeId { get; set; }
        public string PayedMethodName { get; set; }
        public long? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
