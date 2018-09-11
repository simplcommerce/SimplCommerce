using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Localization
{
    public class EfRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var workContext = httpContext.RequestServices.GetRequiredService<IWorkContext>();
            var culture = workContext.GetCurrentUser().Result.Culture;

            if (culture == null)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }

            var providerResultCulture = new ProviderCultureResult(culture);

            return Task.FromResult(providerResultCulture);
        }
    }
}