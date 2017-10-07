using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/appsettings")]
    public class AppSettingApiController : Controller
    {
        private readonly IRepository<AppSetting> _appSettingRepository;
        private readonly IConfigurationRoot _configurationRoot;

        public AppSettingApiController(IRepository<AppSetting> appSettingRepository, IConfiguration configuration)
        {
            _appSettingRepository = appSettingRepository;
            _configurationRoot = (IConfigurationRoot)configuration;
        }

        public IActionResult Get()
        {
            var settings = _appSettingRepository.Query().ToList();
            return Json(settings);
        }

        [HttpPut]
        public IActionResult Put([FromBody] IList<AppSetting> model)
        {
            if (ModelState.IsValid)
            {
                var settings = _appSettingRepository.Query().ToList();
                foreach(var item in settings)
                {
                    var vm = model.FirstOrDefault(x => x.Key == item.Key);
                    if (vm != null)
                    {
                        item.Value = vm.Value;
                    }
                }

                _appSettingRepository.SaveChange();
                _configurationRoot.Reload();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }
    }
}
