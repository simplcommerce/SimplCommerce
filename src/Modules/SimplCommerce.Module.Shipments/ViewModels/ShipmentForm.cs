using System.Collections.Generic;
using SimplCommerce.Module.Shipments.Services;

namespace SimplCommerce.Module.Shipments.ViewModels
{
    public class ShipmentForm
    {
        public long OrderId { get; set; }

        public long WarehouseId { get; set; }

        public string TrackingNumber { get; set; }

        public IList<ShipmentItemVm> Items { get; set; } = new List<ShipmentItemVm>();
    }
}
