using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.ShoppingCart.Models
{
    public class CartItem : EntityBase
    {
        public DateTimeOffset CreatedOn { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public long CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
