using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Notifiers
{
    /// <summary>
    /// If we want to use notification service in core module, we can define the 'INotifier' interface and then implement it in other modules, or use event (E.g: <see cref = "UserSignedInHandler" />).
    /// </summary>
    public interface ITestNotifier
    {
        Task WelcomeToTheApplicationAsync(long userId);

        Task NewUserRegisteredAsync(User user);

        Task SendMessageAsync(long userId, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
