using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    [Authorize(Roles = "admin")]
    [Route("api/appsettings")]
    [ApiController]
    public class AppSettingApiController : ControllerBase
    {
        private readonly IRepositoryWithTypedId<AppSetting, string> _appSettingRepository;
        private readonly IConfigurationRoot _configurationRoot;

        public AppSettingApiController(IRepositoryWithTypedId<AppSetting, string> appSettingRepository, IConfiguration configuration)
        {
            _appSettingRepository = appSettingRepository;
            _configurationRoot = (IConfigurationRoot)configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IList<AppSettingVm>>> Get()
        {
            var settings = await _appSettingRepository.Query()
                .Where(x => x.IsVisibleInCommonSettingPage)
                .Select(x => new AppSettingVm { Key = x.Id, Value = x.Value })
                .ToListAsync();
            return settings;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IList<AppSettingVm> model)
        {
            if (ModelState.IsValid)
            {
                var settings = await _appSettingRepository.Query().Where(x => x.IsVisibleInCommonSettingPage).ToListAsync();
                foreach(var item in settings)
                {
                    var vm = model.FirstOrDefault(x => x.Key == item.Id);
                    if (vm != null)
                    {
                        item.Value = vm.Value;
                    }
                }

                await _appSettingRepository.SaveChangesAsync();
                _configurationRoot.Reload();

                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}
