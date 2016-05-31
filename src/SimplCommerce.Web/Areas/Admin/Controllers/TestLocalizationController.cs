using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace SimplCommerce.Web.Controllers
{
    [Area("Admin")]
    public class TestLocalizationController : Controller
    {
        private IStringLocalizer<SharedResource> _stringLocalizer;

        public TestLocalizationController(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            var locStrings = _stringLocalizer.GetAllStrings();
            return Json(locStrings);
        }
    }
}