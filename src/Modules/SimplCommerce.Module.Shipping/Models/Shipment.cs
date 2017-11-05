using SimplCommerce.Infrastructure.Models;
using System;

namespace SimplCommerce.Module.Shipping.Models
{
    public class Shipment : EntityBase
    {
        protected Shipment()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        public long OrderId { get; set; }

        public long UserId { get; set; }

        public string TrackingNumber { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }
    }
}
