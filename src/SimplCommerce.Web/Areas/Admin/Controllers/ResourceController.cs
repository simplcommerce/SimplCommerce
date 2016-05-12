using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Resources;
using SimplCommerce.Web.Areas.Admin.ViewModels.SmartTable;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ResourceController : Controller
    {
        private readonly IRepository<StringResource> resourceRepository;

        public ResourceController(IRepository<StringResource> resourceRepository)
        {
            this.resourceRepository = resourceRepository;
        }

        public IActionResult List([FromBody] SmartTableParam param)
        {
            var resources = resourceRepository.Query();
            var gridData = resources.ToSmartTableResult(
                param,
                x => new ResourceListItem
                {
                    Id = x.Id,
                    Key = x.Key,
                    Value = x.Value,
                    Culture = x.Culture
                });

            return Json(gridData);
        }

        public IActionResult Get(long id)
        {
            var resource = resourceRepository.Get(id);
            var model = new ResourceForm
            {
                Id = resource.Id,
                Key = resource.Key,
                Value = resource.Value,
                Culture = resource.Culture
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] ResourceForm model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var resource = resourceRepository.Get(id);
            resource.Key = model.Key;
            resource.Value = model.Value;
            resource.Culture = model.Culture;

            resourceRepository.SaveChange();

            return Ok();
        }
    }
}
