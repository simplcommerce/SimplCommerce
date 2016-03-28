using System.Data.Entity;
using AspNet.Identity.EntityFramework6;
using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
{
    public class HvRoleStore : RoleStore<Role, UserRole, RoleClaim, DbContext, long>
    {
        public HvRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}