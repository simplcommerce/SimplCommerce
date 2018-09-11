using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;

namespace SimplCommerce.Module.Localization.Controllers
{
    public class LocalizationController : Controller
    {
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var cultureRepository = HttpContext.RequestServices.GetRequiredService<IRepositoryWithTypedId<Culture, string>>();
            var cultures = cultureRepository.Query().ToList();
            // Reset all the culture and set the default to the selected one
            cultures.ForEach(c => c.IsDefault = (c.Id == culture));
            cultureRepository.SaveChanges();
            GlobalConfiguration.Cultures = cultures;

            return LocalRedirect(returnUrl);
        }
    }
}
