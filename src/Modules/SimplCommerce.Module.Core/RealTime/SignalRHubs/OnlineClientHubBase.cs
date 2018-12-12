using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace SimplCommerce.Module.Core.RealTime.SignalRHubs
{
    public abstract class OnlineClientHubBase : HubBase
    {
        protected IOnlineClientManager OnlineClientManager { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonHub"/> class.
        /// </summary>
        protected OnlineClientHubBase(IOnlineClientManager onlineClientManager)
        {
            OnlineClientManager = onlineClientManager;
            Logger = NullLogger<OnlineClientHubBase>.Instance;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            var client = CreateClientForCurrentConnection();

            Logger.LogDebug("A client is connected: " + client);

            OnlineClientManager.Add(client);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);

            Logger.LogDebug("A client is disconnected: " + Context.ConnectionId);

            try
            {
                OnlineClientManager.Remove(Context.ConnectionId);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex.ToString(), ex);
            }
        }

        protected virtual IOnlineClient CreateClientForCurrentConnection()
        {
            return new OnlineClient(Context.ConnectionId, WorkContent.GetCurrentUser().Result.Id);
        }
    }
}
