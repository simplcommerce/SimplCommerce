using System;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Module.HangfireJobs.Internal
{
    /// <summary>
    /// Defines options for the Hangfire configure.
    /// </summary>
    public class HangfireConfigureOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether the Hangfire background server should be enabled.
        /// </summary>
        public bool EnableServer { get; set; } = true;

        /// <summary>
        /// Gets or sets options for the Hangfire dashboard.
        /// </summary>
        public DasbhoardOptions Dasbhoard { get; set; } = new DasbhoardOptions();

        /// <summary>
        /// Defines options for the Hangfire dashboard.
        /// </summary>
        public class DasbhoardOptions
        {
            /// <summary>
            /// Gets or sets a value indicating whether the Hangfire dashboard should be enabled.
            /// </summary>
            public bool Enabled { get; set; } = true;

            /// <summary>
            /// Gets or sets a value indicating whether the Hangfire dashboard IP-based authorization filter should be enabled.
            /// </summary>
            public bool EnableAuthorization { get; set; } = true;

            /// <summary>
            /// Gets or sets a callback which gets invoked when authorizing a dashboard request.
            /// </summary>
            public Func<HttpContext, bool> AuthorizationCallback { get; set; }
        }
    }
}
