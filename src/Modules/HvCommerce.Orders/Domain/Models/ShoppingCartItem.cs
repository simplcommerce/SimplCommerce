using System;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Orders.Domain.Models
{
    public class ShoppingCartItem : Entity
    {
        public DateTime CreatedOn { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual ProductVariation Product { get; set; }

        public int Quantity { get; set; }
    }
}