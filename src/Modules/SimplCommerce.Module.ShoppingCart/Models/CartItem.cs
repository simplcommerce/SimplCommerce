using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.ShoppingCart.Models
{
    public class CartItem : EntityBase
    {
        public CartItem() 
        {
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
        }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset LatestUpdatedOn { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public long CustomerId { get; set; }

        public User Customer { get; set; }

        public long? VendorId { get; set; }

    }
}
