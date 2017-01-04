using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class Role : IdentityRole<long, UserRole, IdentityRoleClaim<long>>, IEntityWithTypedId<long>
    {
    }
}
