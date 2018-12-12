using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Core.RealTime.SignalRHubs
{
    public abstract class HubBase : Hub
    {
        public ILogger<HubBase> Logger { get; set; }

        public IWorkContext WorkContent { get; set; }

        public ISettingService SettingService { get; set; }

        protected HubBase()
        {
            Logger = NullLogger<HubBase>.Instance;
        }
    }
}
