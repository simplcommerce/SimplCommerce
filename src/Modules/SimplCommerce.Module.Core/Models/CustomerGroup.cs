using SimplCommerce.Infrastructure.Models;
using System.Collections.Generic;

namespace SimplCommerce.Module.Core.Models
{
    public class CustomerGroup : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<UserCustomerGroup> Users { get; set; } = new List<UserCustomerGroup>();
    }
}
