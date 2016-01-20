using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Orders.Domain.Models
{
    public class ShoppingCartItem : Entity
    {
        public DateTime CreatedOn { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
