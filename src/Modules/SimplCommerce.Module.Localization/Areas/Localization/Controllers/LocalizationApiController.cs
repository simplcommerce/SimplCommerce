using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SimplCommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using SimplCommerce.Infrastructure.Localization;
using SimplCommerce.Module.Localization.ViewModel;
using SimplCommerce.Infrastructure;

namespace SimplCommerce.Module.Localization.Controllers
{
    [Area("Localization")]
    [Route("api/localization")]
    public class LocalizationApiController : Controller
    {
        private const string STANDARD_CULTURE_ID = "vi-VN";
        private readonly IStringLocalizer _localizer;
        private readonly IRepository<Resource> _resourceRepository;
        private readonly IRepositoryWithTypedId<Culture, string> _cultureRepository;

        public LocalizationApiController(IStringLocalizerFactory stringLocalizerFactory, IRepository<Resource> resourceRepository, IRepositoryWithTypedId<Culture, string> cultureRepository)
        {
            _localizer = stringLocalizerFactory.Create(null);
            _resourceRepository = resourceRepository;
            _cultureRepository = cultureRepository;
        }

        [HttpGet("get-translation")]
        public IActionResult GetTranslation()
        {
            var strings = _localizer.GetAllStrings().ToDictionary(x => x.Name, x => x.Value);
            return Json(strings);
        }

        [HttpGet("get-cultures")]
        public async Task<IActionResult> GetCultures()
        {
            var cultures = await _cultureRepository.Query().Where(x => x.Id != GlobalConfiguration.DefaultCulture).ToListAsync();
            return Ok(cultures);
        }

        [HttpGet("get-resources")]
        public async Task<IActionResult> GetResources(string cultureId)
        {
            var resources = await _resourceRepository.Query()
                .Where(x => x.CultureId == cultureId)
                .Select(x => new ResourceItemVm {
                    Key = x.Key,
                    Value = x.Value,
                    CultureId = x.CultureId,
                    IsTranslated = true
                })
                .ToListAsync();

            if(cultureId != STANDARD_CULTURE_ID)
            {
                var standardResources = await _resourceRepository.Query()
                .Where(x => x.CultureId == STANDARD_CULTURE_ID)
                .ToListAsync();

                foreach(var item in standardResources)
                {
                    if(resources.All(x => x.Key != item.Key))
                    {
                        resources.Add(new ResourceItemVm { Key = item.Key, CultureId = cultureId, Value = item.Key, IsTranslated = false });
                    }
                }
            }

            return Json(resources.OrderBy(x => x.Key));
        }

        [HttpPost("update-resources")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateResource(string cultureId, [FromBody] IList<ResourceItemVm> model)
        {
            var resources = await _resourceRepository.Query().Where(x => x.CultureId == cultureId).ToListAsync();

            foreach(var resourceItemForm in model)
            {
                var resource = resources.FirstOrDefault(x => x.Key == resourceItemForm.Key);
                if(resource != null)
                {
                    resource.Value = resourceItemForm.Value;
                }
                else if(resourceItemForm.Key != resourceItemForm.Value)
                {
                    _resourceRepository.Add(new Resource
                    {
                        CultureId = cultureId,
                        Key = resourceItemForm.Key,
                        Value = resourceItemForm.Value
                    });
                }
            }

            _resourceRepository.SaveChanges();
            return Accepted();
        }
    }
}
