using System.Data.Entity;
using AspNet.Identity.EntityFramework6;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.ApplicationServices
{
    public class HvRoleStore : RoleStore<Role, UserRole, RoleClaim, DbContext, long>
    {
        public HvRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}