using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Catalog.Models;
using System;

namespace SimplCommerce.Module.WishList.Models
{
    public class WishListItem : EntityBase
    {
        public WishListItem()
        {
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
        }

        public long WishListId { get; set; }

        public WishList WishList { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set;}

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset LatestUpdatedOn { get; set; }
    }
}
