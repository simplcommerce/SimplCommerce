using SimplCommerce.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Core.Models
{
    public class CustomerGroup : EntityBase
    {
        public CustomerGroup()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public IList<UserCustomerGroup> Users { get; set; } = new List<UserCustomerGroup>();
    }
}
