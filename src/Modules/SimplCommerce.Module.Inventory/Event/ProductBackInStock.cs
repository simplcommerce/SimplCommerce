using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SimplCommerce.Module.Inventory.Event
{
    public class ProductBackInStock : INotification
    {
        public long ProductId { get; set; }
    }
}
