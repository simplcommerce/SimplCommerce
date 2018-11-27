using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    [Authorize(Roles = "admin")]
    [Route("api/themes")]
    public class ThemeApiController : Controller
    {
        private readonly IThemeService _themeService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ThemeApiController(IThemeService themeService, IHttpClientFactory httpClientFactory)
        {
            _themeService = themeService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var themes = await _themeService.GetInstalledThemes();
            return Json(themes);
        }

        [HttpGet("/api/online-themes")]
        public async Task<IActionResult> GetOnlineThemes()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://marketplace.simplcommerce.com/api/projects/themes");
            response.EnsureSuccessStatusCode();

            var onlineThemes = await response.Content.ReadAsAsync<List<ProjectItemVm>>();
            return Ok(onlineThemes);
        }

        [HttpGet("/api/online-themes/{name}")]
        public async Task<IActionResult> Details(string name)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://marketplace.simplcommerce.com/api/projects/{name}");
            response.EnsureSuccessStatusCode();

            var projectDetailsVm = await response.Content.ReadAsAsync<ProjectDetailsVm>();

            var installedThemes = await _themeService.GetInstalledThemes();
            projectDetailsVm.IsInstalled = installedThemes.Any(x => x.Name == name);

            return Ok(projectDetailsVm);
        }

        [HttpPut("/api/online-themes/{name}/install")]
        public async Task<IActionResult> Install(string name)
        {
            var installedThemes = await _themeService.GetInstalledThemes();
            if(installedThemes.Any(x => x.Name == name))
            {
                return NoContent();
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://marketplace.simplcommerce.com/api/projects/{name}/download");
            response.EnsureSuccessStatusCode();

            var responsStream = await response.Content.ReadAsStreamAsync();
            await _themeService.Install(responsStream, name);

            return Accepted();
        }

        [HttpDelete("{themeName}")]
        public IActionResult Delete(string themeName)
        {
            _themeService.Delete(themeName);
            return NoContent();
        }

        [HttpPost("use-theme")]
        public async Task<IActionResult> Post([FromBody] ThemeListItem model)
        {
            if (ModelState.IsValid)
            {
                await _themeService.SetCurrentTheme(model.Name);

                return Accepted();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{themeName}/download")]
        public IActionResult Download(string themeName)
        {
            var filePath = _themeService.PackTheme(themeName);
            var fileStream = new FileStream(filePath, FileMode.Open);
            return File(fileStream, "application/octet-stream", $"{themeName}.zip");
        }
    }
}
