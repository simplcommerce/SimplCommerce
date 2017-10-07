using System;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.ProductRecentlyViewed.Models
{
    public class RecentlyViewedProduct : EntityBase
    {
        public long UserId { get; set; }

        public long ProductId { get; set; }

        public DateTimeOffset LatestViewedOn { get; set; }
    }
}
