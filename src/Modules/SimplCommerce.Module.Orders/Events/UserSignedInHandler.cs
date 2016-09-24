using MediatR;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;

namespace SimplCommerce.Module.Orders.Events
{
    public class UserSignedInHandler : INotificationHandler<UserSignedIn>
    {
        private readonly IWorkContext _workContext;
        private readonly ICartService _cartService;

        public UserSignedInHandler(IWorkContext workContext, ICartService cartService)
        {
            _workContext = workContext;
            _cartService = cartService;
        }

        public void Handle(UserSignedIn user)
        {
            var guestUser = _workContext.GetCurrentUser().Result;
            _cartService.MigrateCart(guestUser.Id, user.UserId);
        }
    }
}
