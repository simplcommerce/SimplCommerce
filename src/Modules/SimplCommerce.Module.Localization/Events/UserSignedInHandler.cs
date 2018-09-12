using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.ShoppingCart.Events
{
    public class UserSignedInHandler : INotificationHandler<UserSignedIn>
    {
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<User, long> _userRepository;

        public UserSignedInHandler(IWorkContext workContext, IRepositoryWithTypedId<User, long> userRepository)
        {
            _workContext = workContext;
            _userRepository = userRepository;
        }

        public async Task Handle(UserSignedIn user, CancellationToken cancellationToken)
        {
            var guestUser = await _workContext.GetCurrentUser();
            var currentUser = _userRepository.Query().Single(u => u.Id == user.UserId);
            _userRepository.Query().Single(u => u.Id == guestUser.Id).Culture = currentUser.Culture;
        }
    }
}
