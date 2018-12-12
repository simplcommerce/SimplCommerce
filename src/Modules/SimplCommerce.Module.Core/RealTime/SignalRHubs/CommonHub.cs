using Microsoft.Extensions.Logging;

namespace SimplCommerce.Module.Core.RealTime.SignalRHubs
{
    public class CommonHub : OnlineClientHubBase
    {
        public CommonHub(IOnlineClientManager onlineClientManager) : base(onlineClientManager)
        {
        }

        public void Register()
        {
            Logger.LogDebug("A client is registered: " + Context.ConnectionId);
        }
    }
}
