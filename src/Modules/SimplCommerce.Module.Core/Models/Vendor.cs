using System;
using System.Collections.Generic;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class Vendor : EntityBase
    {
        public Vendor()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public string Name { get; set; }

        public string SeoTitle { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public IList<User> Users { get; set; } = new List<User>();
    }
}
