using Microsoft.Extensions.Logging;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.SignalR.RealTime;

namespace SimplCommerce.Module.SignalR.Hubs
{
    public class CommonHub : OnlineClientHubBase
    {
        public CommonHub(IWorkContext workContext, IOnlineClientManager onlineClientManager) : base(workContext, onlineClientManager)
        {
        }

        public void Register()
        {
            Logger.LogDebug("A client is registered: " + Context.ConnectionId);
        }
    }
}
