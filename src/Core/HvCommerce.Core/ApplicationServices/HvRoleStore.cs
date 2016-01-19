using AspNet.Identity.EntityFramework6;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Core.Infrastructure.EntityFramework;

namespace HvCommerce.Core.ApplicationServices
{
    public class HvRoleStore : RoleStore<Role, UserRole, RoleClaim, HvDbContext, long>
    {
        public HvRoleStore(HvDbContext context)
            : base(context)
        {
        }
    }
}