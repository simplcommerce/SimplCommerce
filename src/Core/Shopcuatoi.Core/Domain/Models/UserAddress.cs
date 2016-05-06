using System;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class UserAddress : Entity
    {
        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long AddressId { get; set; }

        public virtual Address Address { get; set; }

        public AddressType AddressType { get; set; }

        public DateTime? LastUsedOn { get; set; }
    }
}