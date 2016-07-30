using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Orders.Models
{
    public class OrderItem : Entity
    {
        public virtual Order Order { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}
