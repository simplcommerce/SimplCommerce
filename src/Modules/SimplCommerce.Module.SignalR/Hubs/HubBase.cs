using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.SignalR.Hubs
{
    public abstract class HubBase : Hub
    {
        public ILogger<HubBase> Logger { get; set; }

        protected IWorkContext WorkContent { get; }

        protected HubBase(IWorkContext workContent)
        {
            Logger = NullLogger<HubBase>.Instance;
            WorkContent = workContent;
        }
    }
}
