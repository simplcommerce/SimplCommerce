using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var signedInUser = await _userRepository.Query().SingleAsync(u => u.Id == user.UserId);
            signedInUser.Culture = guestUser.Culture;
            await _userRepository.SaveChangesAsync();
        }
    }
}
