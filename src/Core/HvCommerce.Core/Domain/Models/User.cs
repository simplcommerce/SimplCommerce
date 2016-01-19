using System;
using AspNet.Identity.EntityFramework6;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class User : IdentityUser<long, UserLogin, UserRole, UserClaim>, IEntityWithTypedId<long>
    {
        public User()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public string FullName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}