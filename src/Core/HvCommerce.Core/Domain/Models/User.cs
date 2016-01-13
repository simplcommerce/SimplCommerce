using Microsoft.AspNet.Identity;
using AspNet.Identity.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Core.Domain.Models
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public string Test { get; set; }
    }
}
