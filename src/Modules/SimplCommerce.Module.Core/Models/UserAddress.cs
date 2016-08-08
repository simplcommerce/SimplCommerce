using System;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class UserAddress : Entity
    {
        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long AddressId { get; set; }

        public virtual Address Address { get; set; }

        public AddressType AddressType { get; set; }

        public DateTimeOffset? LastUsedOn { get; set; }
    }
}
