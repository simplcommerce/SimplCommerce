using Microsoft.AspNetCore.Identity;
using SimplCommerce.Infrastructure.Models;
using System.Collections.Generic;

namespace SimplCommerce.Module.Core.Models
{
    public class Role : IdentityRole<long, UserRole, IdentityRoleClaim<long>>, IEntityWithTypedId<long>
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
