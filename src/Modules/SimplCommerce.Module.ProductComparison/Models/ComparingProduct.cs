using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.ProductComparison.Models
{
    public class ComparingProduct : EntityBase
    {
        public DateTimeOffset CreatedOn { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }
    }
}
