using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Notifications.Notifiers;

namespace SimplCommerce.Module.Notifications.Events
{
    public class UserSignedInHandler : INotificationHandler<UserSignedIn>
    {
        private readonly ITestNotifier _testNotifier;

        public UserSignedInHandler(ITestNotifier testNotifier)
        {
            _testNotifier = testNotifier;
        }

        /// <inheritdoc />
        public Task Handle(UserSignedIn notification, CancellationToken cancellationToken)
        {
            //Edit: Demo for how to use notification service in core module.
            //await _testNotifier.WelcomeToTheApplicationAsync(notification.UserId);
            return Task.FromResult(0);
        }
    }
}
