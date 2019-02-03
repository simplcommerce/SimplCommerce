using System;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace SimplCommerce.Module.HangfireJobs.Internal
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        private readonly Func<HttpContext, bool> _authorizationCallback;

        public ILogger<HangfireDashboardAuthorizationFilter> Logger { get; set; }

        public HangfireDashboardAuthorizationFilter(Func<HttpContext, bool> authorizationCallback = null)
        {
            _authorizationCallback = authorizationCallback;
            Logger = NullLogger<HangfireDashboardAuthorizationFilter>.Instance;
        }

        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            return _authorizationCallback != null ? InvokeAuthorizationCallback(httpContext) : httpContext.User.Identity.IsAuthenticated;
        }

        private bool InvokeAuthorizationCallback(HttpContext httpContext)
        {
            if (_authorizationCallback.Invoke(httpContext))
            {
                Logger.LogDebug("Grant access to dashboard");
                return true;
            }

            Logger.LogWarning("Deny access to dashboard");
            return false;
        }
    }
}
