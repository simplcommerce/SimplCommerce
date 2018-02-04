using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Inventory.Models
{
    public class Warehouse : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
