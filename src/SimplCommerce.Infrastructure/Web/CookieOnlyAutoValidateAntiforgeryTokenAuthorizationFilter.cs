using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SimplCommerce.Infrastructure.Web
{
    public class CookieOnlyAutoValidateAntiforgeryTokenAuthorizationFilter(IAntiforgery antiforgery) : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            if (HttpMethods.IsGet(httpContext.Request.Method) ||
                HttpMethods.IsHead(httpContext.Request.Method) ||
                HttpMethods.IsOptions(httpContext.Request.Method) ||
                HttpMethods.IsTrace(httpContext.Request.Method))
            {
                return;
            }

            if (!httpContext.Request.Path.StartsWithSegments("/api"))
            {
                return;
            }

            if (httpContext.User.Identity?.AuthenticationType != "Identity.Application")
            {
                return;
            }

            try
            {
                await antiforgery.ValidateRequestAsync(httpContext);
            }
            catch (AntiforgeryValidationException)
            {
                context.Result = new AntiforgeryValidationFailedResult();
            }
        }
    }
}
