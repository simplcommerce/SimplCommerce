using System;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Orders.Domain.Models
{
    public class CartItem : Entity
    {
        public DateTime CreatedOn { get; set; }

        public Guid? GuestId { get; set; }

        public long? CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public long? ProductVariationId { get; set; }

        public virtual ProductVariation ProductVariation { get; set; }

        public int Quantity { get; set; }

        public decimal ProductPrice
        {
            get
            {
                if (ProductVariationId.HasValue)
                {
                    return Product.Price + ProductVariation.PriceOffset;
                }

                return Product.Price;
            }
        }
    }
}