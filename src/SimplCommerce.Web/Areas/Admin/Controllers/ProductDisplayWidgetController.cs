using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Cms;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductDisplayWidgetController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;

        public ProductDisplayWidgetController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRepository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRepository;
        }

        public IActionResult Get(long id)
        {
            var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ProductDisplayWidgetForm
            {
                Id = widgetInstance.Id,
                Name = widgetInstance.Name,
                WidgetZoneId = widgetInstance.WidgetZoneId,
                Setting = JsonConvert.DeserializeObject<WidgetProductDisplaySetting>(widgetInstance.Data)
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDisplayWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = 3,
                    WidgetZoneId = model.WidgetZoneId,
                    Data = JsonConvert.SerializeObject(model.Setting)
                };

                _widgetInstanceRepository.Add(widgetInstance);
                _widgetInstanceRepository.SaveChange();
                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] ProductDisplayWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
                widgetInstance.Name = model.Name;
                widgetInstance.WidgetZoneId = model.WidgetZoneId;
                widgetInstance.Data = JsonConvert.SerializeObject(model.Setting);

                _widgetInstanceRepository.SaveChange();
                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }
    }
}
