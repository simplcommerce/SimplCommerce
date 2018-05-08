using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public async Task<IActionResult> Get()
        {
            var themes = await _themeService.GetInstalledThemes();
            return Json(themes);
        }

        [HttpGet("/api/online-themes")]
        public async Task<IActionResult> GetOnlineThemes()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://marketplace.simplcommerce.com/api/projects/themes");
            var onlineThemes = new List<ProjectItemVm>();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                onlineThemes = JsonConvert.DeserializeObject<List<ProjectItemVm>>(json);
            }

            return Ok(onlineThemes);
        }

        [HttpGet("/api/online-themes/{name}")]
        public async Task<IActionResult> Details(string name)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://marketplace.simplcommerce.com/api/projects/{name}");
            var projectDetailsVm = new ProjectDetailsVm();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                projectDetailsVm = JsonConvert.DeserializeObject<ProjectDetailsVm>(json);
            }

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

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://marketplace.simplcommerce.com/api/projects/{name}");
            var projectDetailsVm = new ProjectDetailsVm();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                projectDetailsVm = JsonConvert.DeserializeObject<ProjectDetailsVm>(json);
            }

            HttpResponseMessage response2 = await client.GetAsync($"http://marketplace.simplcommerce.com/api/projects/{name}/download");
            if (response2.IsSuccessStatusCode)
            {
                var responsStream = await response2.Content.ReadAsStreamAsync();
                await _themeService.Install(responsStream, projectDetailsVm.Name);
            }

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
