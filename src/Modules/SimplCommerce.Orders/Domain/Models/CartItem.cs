using System;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Orders.Domain.Models
{
    public class CartItem : Entity
    {
        public DateTime CreatedOn { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}