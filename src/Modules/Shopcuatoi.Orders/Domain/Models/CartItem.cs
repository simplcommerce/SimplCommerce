using System;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Orders.Domain.Models
{
    public class CartItem : Entity
    {
        public DateTime CreatedOn { get; set; }

        public Guid? GuestKey { get; set; }

        public long CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public long? ProductVariationId { get; set; }

        public virtual ProductVariation ProductVariation { get; set; }

        public int Quantity { get; set; }
    }
}