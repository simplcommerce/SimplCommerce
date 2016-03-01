using System.Data.Entity;
using AspNet.Identity.EntityFramework6;
using HvCommerce.Core.Domain.Models;

namespace HvCommerce.Core.ApplicationServices
{
    public class HvRoleStore : RoleStore<Role, UserRole, RoleClaim, DbContext, long>
    {
        public HvRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}