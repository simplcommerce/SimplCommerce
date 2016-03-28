using System.Data.Entity;
using AspNet.Identity.EntityFramework6;
using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
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