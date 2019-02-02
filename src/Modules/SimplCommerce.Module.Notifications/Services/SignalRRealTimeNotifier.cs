using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SimplCommerce.Module.Notifications.Models;
using SimplCommerce.Module.SignalR.Hubs;
using SimplCommerce.Module.SignalR.RealTime;

namespace SimplCommerce.Module.Notifications.Services
{
    /// <summary>
    /// Null pattern implementation of <see cref="IRealTimeNotifier"/>.
    /// </summary>
    public class SignalRRealTimeNotifier : IRealTimeNotifier
    {
        /// <summary>
        /// Reference to the logger.
        /// </summary>
        public ILogger<SignalRRealTimeNotifier> Logger { get; set; }

        private readonly IOnlineClientManager _onlineClientManager;

        private readonly IHubContext<CommonHub> _hubContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRRealTimeNotifier"/> class.
        /// </summary>
        public SignalRRealTimeNotifier(IOnlineClientManager onlineClientManager, IHubContext<CommonHub> hubContext)
        {
            _onlineClientManager = onlineClientManager;
            _hubContext = hubContext;
            Logger = NullLogger<SignalRRealTimeNotifier>.Instance;
        }

        /// <inheritdoc/>
        public Task SendNotificationsAsync(UserNotificationDto[] userNotifications)
        {
            foreach (var userNotification in userNotifications)
            {
                try
                {
                    var onlineClients = _onlineClientManager.GetAllByUserId(userNotification.UserId);
                    foreach (var onlineClient in onlineClients)
                    {
                        var signalRClient = _hubContext.Clients.Client(onlineClient.ConnectionId);
                        if (signalRClient == null)
                        {
                            Logger.LogDebug($"Can not get user {userNotification.UserId} with connectionId {onlineClient.ConnectionId} from SignalR hub!");
                            continue;
                        }

                        signalRClient.SendAsync("getNotification", userNotification);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogWarning($"Could not send notification to user: {userNotification.UserId}.");
                    Logger.LogWarning(ex.ToString(), ex);
                }
            }

            return Task.FromResult(0);
        }
    }
}
