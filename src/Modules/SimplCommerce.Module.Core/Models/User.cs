using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class User : IdentityUser<long, IdentityUserClaim<long>, UserRole, IdentityUserLogin<long>>, IEntityWithTypedId<long>
    {
        public User()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        public Guid UserGuid { get; set; }

        public string FullName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public virtual IList<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

        public virtual UserAddress CurrentShippingAddress { get; set; }

        public long? CurrentShippingAddressId { get; set; }
    }
}
