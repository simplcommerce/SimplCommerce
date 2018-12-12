using Microsoft.Extensions.Logging;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Core.RealTime.SignalRHubs
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
