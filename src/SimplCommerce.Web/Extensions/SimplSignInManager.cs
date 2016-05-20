using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimplCommerce.Orders.ApplicationServices;
using System;
using System.Threading.Tasks;

namespace SimplCommerce.Web.Extensions
{
    public class SimplSignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICartService _cartService;
        private HttpContext _context;

        public SimplSignInManager(UserManager<TUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger,
            ICartService cartService)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
            _cartService = cartService;
            _contextAccessor = contextAccessor;
        }

        internal HttpContext Context
        {
            get
            {
                var context = _context ?? _contextAccessor?.HttpContext;
                if (context == null)
                {
                    throw new InvalidOperationException("HttpContext must not be null.");
                }
                return context;
            }
            set
            {
                _context = value;
            }
        }

        public override async Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null)
        {
            await ChangeGuestIdToUser(user);
            await base.SignInAsync(user, isPersistent, authenticationMethod);
        }

        private async Task ChangeGuestIdToUser(TUser user)
        {
            var guestId = GuestIdentityManager.GetGuestId(Context);
            if (!guestId.HasValue)
            {
                return;
            }

            var userId = await UserManager.GetUserIdAsync(user);

            _cartService.UpdateGuestIdToUser(guestId.Value, long.Parse(userId));
        }
    }
}
