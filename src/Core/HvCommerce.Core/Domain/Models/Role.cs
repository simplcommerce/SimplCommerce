using AspNet.Identity.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Core.Domain.Models
{
    public class Role : IdentityRole<int, UserRole, RoleClaim>
    {
        public Role() { }

        public Role(string name)
        {
            Name = name;
        }
    }
}
