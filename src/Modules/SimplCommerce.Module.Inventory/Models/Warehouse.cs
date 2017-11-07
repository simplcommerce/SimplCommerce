using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Inventory.Models
{
    public class Warehouse : EntityBase
    {
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
