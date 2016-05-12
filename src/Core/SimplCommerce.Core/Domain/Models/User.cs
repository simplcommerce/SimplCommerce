using System;
using System.Collections.Generic;
using AspNet.Identity.EntityFramework6;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Core.Domain.Models
{
    public class User : IdentityUser<long, UserLogin, UserRole, UserClaim>, IEntityWithTypedId<long>
    {
        public User()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public string FullName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual IList<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

        public virtual UserAddress CurrentShippingAddress { get; set; }

        public long? CurrentShippingAddressId { get; set; }
    }
}