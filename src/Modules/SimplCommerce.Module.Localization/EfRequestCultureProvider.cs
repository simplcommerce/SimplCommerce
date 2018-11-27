using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Localization
{
    public class EfRequestCultureProvider : RequestCultureProvider
    {
        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var workContext = httpContext.RequestServices.GetRequiredService<IWorkContext>();
            var user = await workContext.GetCurrentUser();
            var culture = user.Culture;

            if (culture == null)
            {
                return await Task.FromResult((ProviderCultureResult)null);
            }

            var providerResultCulture = new ProviderCultureResult(culture);

            return await Task.FromResult(providerResultCulture);
        }
    }
}