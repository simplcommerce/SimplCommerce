using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class User : IdentityUser<long>, IEntityWithTypedId<long>
    {
        public User()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public Guid UserGuid { get; set; }

        public string FullName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual IList<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

        public virtual UserAddress CurrentShippingAddress { get; set; }

        public long? CurrentShippingAddressId { get; set; }
    }
}
