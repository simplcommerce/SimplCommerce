using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}