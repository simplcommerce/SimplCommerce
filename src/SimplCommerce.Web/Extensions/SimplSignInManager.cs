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
        private readonly IWorkContext _workContext;
        private HttpContext _context;

        public SimplSignInManager(UserManager<TUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger,
            ICartService cartService,
            IWorkContext workContext)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
            _cartService = cartService;
            _contextAccessor = contextAccessor;
            _workContext = workContext;
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
            await MigrateCart(user);
            await base.SignInAsync(user, isPersistent, authenticationMethod);
        }

        private async Task MigrateCart(TUser user)
        {
            var guestUser = await _workContext.GetCurrentUser();
            var userId = await UserManager.GetUserIdAsync(user);
            _cartService.MigrateCart(guestUser.Id, long.Parse(userId));
        }
    }
}
