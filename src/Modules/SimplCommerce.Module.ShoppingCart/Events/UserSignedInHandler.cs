using System.Threading.Tasks;
using MediatR;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.ShoppingCart.Events
{
    public class UserSignedInHandler : IAsyncNotificationHandler<UserSignedIn>
    {
        private readonly IWorkContext _workContext;
        private readonly ICartService _cartService;

        public UserSignedInHandler(IWorkContext workContext, ICartService cartService)
        {
            _workContext = workContext;
            _cartService = cartService;
        }

        public async Task Handle(UserSignedIn user)
        {
            var guestUser = await _workContext.GetCurrentUser();
            await _cartService.MigrateCart(guestUser.Id, user.UserId);
        }
    }
}
