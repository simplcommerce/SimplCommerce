using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Shipments.Models
{
    public class Shipment : EntityBase
    {
        protected Shipment()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        public long OrderId { get; set; }

        public Order Order { get; set; }

        public long UserId { get; set; }

        public string TrackingNumber { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }
    }
}
