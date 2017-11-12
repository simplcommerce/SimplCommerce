using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Shipping.Services
{
    public class ShippingItem
    {
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
