using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.ProductComparison.Models
{
    public class ProductComparisonItem : EntityBase
    {
        public DateTimeOffset CreatedOn { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }      

        public long ProductId { get; set; }

        public virtual Product Product { get; set; } 
    }
}
