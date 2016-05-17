using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Core.Domain.Models
{
    public class Role : IdentityRole<long>, IEntityWithTypedId<long>
    {
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }
    }
}