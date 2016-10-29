using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Orders.Models
{
    public class CartItem : EntityBase
    {
        public DateTimeOffset CreatedOn { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
