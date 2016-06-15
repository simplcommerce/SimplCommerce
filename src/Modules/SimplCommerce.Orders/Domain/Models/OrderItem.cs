using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Orders.Domain.Models
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