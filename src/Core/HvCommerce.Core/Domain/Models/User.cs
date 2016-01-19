using AspNet.Identity.EntityFramework6;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class User : IdentityUser<long, UserLogin, UserRole, UserClaim>, IEntityWithTypedId<long>
    {
        public string FullName { get; set; }
    }
}
