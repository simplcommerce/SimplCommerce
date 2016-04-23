using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Orders.Domain.Models
{
    public class OrderItem : Entity
    {
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public long? ProductVariationId { get; set; }

        public virtual ProductVariation ProductVariation { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}