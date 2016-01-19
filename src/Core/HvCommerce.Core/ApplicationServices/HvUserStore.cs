using AspNet.Identity.EntityFramework6;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Core.Infrastructure.EntityFramework;

namespace HvCommerce.Core.ApplicationServices
{
    public class HvUserStore : UserStore<User, Role, UserRole, UserClaim,
        UserLogin, RoleClaim, HvDbContext, long>
    {
        public HvUserStore(HvDbContext context)
            : base(context)
        {
        }
    }
}