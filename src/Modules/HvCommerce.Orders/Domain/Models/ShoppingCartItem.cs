using System;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Orders.Domain.Models
{
    public class ShoppingCartItem : Entity
    {
        public DateTime CreatedOn { get; set; }

        public long CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public long ProductVariationId { get; set; }

        public virtual ProductVariation ProductVariation { get; set; }

        public int Quantity { get; set; }
    }
}