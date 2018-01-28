using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Shipments.Models
{
    public class ShipmentItem : EntityBase
    {
        public long ShipmentId { get; set; }

        public Shipment Shipment { get; set; }

        public long OrderItemId { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
