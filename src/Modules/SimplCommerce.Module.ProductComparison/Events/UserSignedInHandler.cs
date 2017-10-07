using MediatR;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.ProductComparison.Services;

namespace SimplCommerce.Module.ProductComparison.Events
{
    public class UserSignedInHandler : INotificationHandler<UserSignedIn>
    {
        private readonly IWorkContext _workContext;
        private readonly IComparingProductService _comparingService;

        public UserSignedInHandler(IWorkContext workContext, IComparingProductService comparingService)
        {
            _workContext = workContext;
            _comparingService = comparingService;
        }

        public void Handle(UserSignedIn user)
        {
            var guestUser = _workContext.GetCurrentUser().Result;
            _comparingService.MigrateComparingProduct(guestUser.Id, user.UserId);
        }
    }
}
