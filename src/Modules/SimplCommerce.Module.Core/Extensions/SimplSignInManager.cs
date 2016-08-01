using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MediatR;
using SimplCommerce.Module.Core.Events;

namespace SimplCommerce.Module.Core.Extensions
{
    public class SimplSignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWorkContext _workContext;
        private HttpContext _context;
        private IMediator _mediator;

        public SimplSignInManager(UserManager<TUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger,
            IWorkContext workContext,
            IMediator mediator)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
            _contextAccessor = contextAccessor;
            _workContext = workContext;
            _mediator = mediator;
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
            var userId = await UserManager.GetUserIdAsync(user);
            _mediator.Publish(new UserSignedIn { UserId = long.Parse(userId) });
            await base.SignInAsync(user, isPersistent, authenticationMethod);
        }
    }
}
