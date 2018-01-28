using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Payments.Models
{
    public class Payment : EntityBase
    {
        public long OrderId { get; set; }

        public Order Order { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public string GatewayTransactionId { get; set; }

        public PaymentStatus Status { get; set; }

        public string FailureMessage { get; set; }
    }
}
