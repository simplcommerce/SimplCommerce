using AspNet.Identity.EntityFramework6;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class Role : IdentityRole<long, UserRole, RoleClaim>, IEntityWithTypedId<long>
    {
        public Role() { }

        public Role(string name)
        {
            Name = name;
        }
    }
}
