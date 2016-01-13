using HvCommerce.Core.Domain.Models;
using HvCommerce.Core.Infrastructure.EntityFramework;
using AspNet.Identity.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Core.ApplicationServices
{
    public class HvRoleStore : RoleStore<Role, UserRole, RoleClaim, HvDbContext, int>
    {
        public HvRoleStore(HvDbContext context)
        : base(context)
        {
        }
    }
}
