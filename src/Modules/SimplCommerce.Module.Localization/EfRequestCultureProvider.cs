using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using SimplCommerce.Infrastructure;

namespace SimplCommerce.Module.Localization
{
    public class EfRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var culture = GlobalConfiguration.Cultures.Where(c => c.IsDefault).Select(c => c.Id).FirstOrDefault();

            if (culture == null)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }

            var providerResultCulture = new ProviderCultureResult(culture);

            return Task.FromResult(providerResultCulture);
        }
    }
}