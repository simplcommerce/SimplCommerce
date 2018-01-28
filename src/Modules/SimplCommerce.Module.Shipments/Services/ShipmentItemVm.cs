namespace SimplCommerce.Module.Shipments.Services
{
    public class ShipmentItemVm
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductSku { get; set; }

        public long OrderItemId { get; set; }

        public int OrderedQuantity { get; set; }

        public int ShippedQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int QuantityToShip { get; set; }
    }
}
