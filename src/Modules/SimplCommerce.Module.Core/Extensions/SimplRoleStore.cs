using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Extensions
{
    public class SimplRoleStore: RoleStore<Role, SimplDbContext, long, UserRole, IdentityRoleClaim<long>>
    {
        public SimplRoleStore(SimplDbContext context) : base(context)
        {
        }
    }
}
