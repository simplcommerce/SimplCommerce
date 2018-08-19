using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.WishList.Models
{
    public class WishList : EntityBase
    {
        public WishList()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        public long UserId { get; set; }

        public User User { get; set; }

        public string SharingCode { get; set; }

        public IList<WishListItem> Items { get; protected set; } = new List<WishListItem>();

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }
    }
}
