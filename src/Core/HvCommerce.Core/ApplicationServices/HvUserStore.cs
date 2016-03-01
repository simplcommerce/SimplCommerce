using System.Data.Entity;
using AspNet.Identity.EntityFramework6;
using HvCommerce.Core.Domain.Models;

namespace HvCommerce.Core.ApplicationServices
{
    public class HvUserStore : UserStore<User, Role, UserRole, UserClaim,
        UserLogin, RoleClaim, DbContext, long>
    {
        public HvUserStore(DbContext context)
            : base(context)
        {
        }
    }
}