using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/themes")]
    public class ThemeApiController : Controller
    {
        private readonly IThemeService _themeService;

        public ThemeApiController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        public IActionResult Get()
        {
            var themes = _themeService.GetInstalledThemes();
            return Json(themes);
        }

        [HttpPost("use-theme")]
        public IActionResult Post([FromBody] ThemeListItem model)
        {
            if (ModelState.IsValid)
            {
                _themeService.SetCurrentTheme(model.Name);

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }
    }
}
