using System;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.Logging;

namespace SimplCommerce.Infrastructure.Web
{
    public class CookieOnlyAutoValidateAntiforgeryTokenAuthorizationFilter : AutoValidateAntiforgeryTokenAuthorizationFilter
    {
        public CookieOnlyAutoValidateAntiforgeryTokenAuthorizationFilter(IAntiforgery antiforgery, ILoggerFactory loggerFactory)
            : base(antiforgery, loggerFactory)
        {
        }

        protected override bool ShouldValidate(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!context.HttpContext.Request.Path.StartsWithSegments("/api"))
            {
                return false;
            }

            if (context.HttpContext.User.Identity?.AuthenticationType != "Identity.Application")
            {
                return false;
            }

            return base.ShouldValidate(context);
        }
    }
}
