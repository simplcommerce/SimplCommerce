using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace SimplCommerce.Module.Localization.Controllers
{
    [Route("api/localization")]
    public class LocalizationApiController : Controller
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationApiController(IStringLocalizerFactory stringLocalizerFactory)
        {
            _localizer = stringLocalizerFactory.Create(null);
        }

        [HttpGet("get-translation")]
        public IActionResult GetTranslation()
        {
            var strings = _localizer.GetAllStrings().ToDictionary(x => x.Name, x => x.Value);
            return Json(strings);
        }
    }
}
