using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Inventory.Models
{
    public class ProductBackInStockSubscription : EntityBase
    {
        public long ProductId { get; set; }

        public string CustomerEmail { get; set; }
    }
}
