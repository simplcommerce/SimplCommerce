using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.WebHost.IdentityServer
{
    public class SimplProfileService : IProfileService
    {
        public SimplProfileService(UserManager<User> userManager,
            IUserClaimsPrincipalFactory<User> claimsFactory,
            ILogger<ProfileService<User>> logger)
        {
            ClaimsFactory = claimsFactory;
            Logger = logger;
            UserManager = userManager;
        }

        protected readonly IUserClaimsPrincipalFactory<User> ClaimsFactory;

        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger<ProfileService<User>> Logger;

        /// <summary>
        /// The user manager.
        /// </summary>
        protected readonly UserManager<User> UserManager;

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject?.GetSubjectId();
            if (sub == null) throw new Exception("No sub claim present");

            var user = await UserManager.FindByIdAsync(sub);
            if (user == null)
            {
                Logger?.LogWarning("No user found matching subject Id: {0}", sub);
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                };

                var userRoles = await UserManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                context.IssuedClaims.AddRange(claims);
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject?.GetSubjectId();
            if (sub == null) throw new Exception("No subject Id claim present");

            var user = await UserManager.FindByIdAsync(sub);
            if (user == null)
            {
                Logger?.LogWarning("No user found matching subject Id: {0}", sub);
            }

            context.IsActive = user != null;
        }
    }
}
