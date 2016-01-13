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
    public class HvUserStore : UserStore<User, Role, UserRole, UserClaim,
        UserLogin, RoleClaim, HvDbContext, int>
    {
        public HvUserStore(HvDbContext context)
        : base(context)
        {
        }
    }
}
