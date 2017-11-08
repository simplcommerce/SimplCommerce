using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Shipping.Models
{
    public class ShipmentItem : EntityBase
    {
        public long ShipmentId { get; set; }

        public Shipment Shipment { get; set; }

        public long OrderItemId { get; set; }

        public int Quantity { get; set; }
    }
}
