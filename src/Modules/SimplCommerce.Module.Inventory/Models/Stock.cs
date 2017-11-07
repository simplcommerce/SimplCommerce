using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Inventory.Models
{
    public class Stock : EntityBase
    {
        public long ProductId { get; set; }

        public long WarehouseId { get; set; }

        public int Quantity { get; set; }
    }
}
