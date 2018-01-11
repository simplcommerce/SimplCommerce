using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Catalog.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/product-widgets")]
    public class ProductWidgetApiController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;

        public ProductWidgetApiController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRepository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ProductWidgetForm
            {
                Id = widgetInstance.Id,
                Name = widgetInstance.Name,
                WidgetZoneId = widgetInstance.WidgetZoneId,
                PublishStart = widgetInstance.PublishStart,
                PublishEnd = widgetInstance.PublishEnd,
                DisplayOrder = widgetInstance.DisplayOrder,
                Setting = JsonConvert.DeserializeObject<ProductWidgetSetting>(widgetInstance.Data)
            };

            var enumMetaData = MetadataProvider.GetMetadataForType(typeof(ProductWidgetOrderBy));

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = 3,
                    WidgetZoneId = model.WidgetZoneId,
                    PublishStart = model.PublishStart,
                    PublishEnd = model.PublishEnd,
                    DisplayOrder = model.DisplayOrder,
                    Data = JsonConvert.SerializeObject(model.Setting)
                };

                _widgetInstanceRepository.Add(widgetInstance);
                _widgetInstanceRepository.SaveChanges();
                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ProductWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
                widgetInstance.Name = model.Name;
                widgetInstance.WidgetZoneId = model.WidgetZoneId;
                widgetInstance.PublishStart = model.PublishStart;
                widgetInstance.PublishEnd = model.PublishEnd;
                widgetInstance.DisplayOrder = model.DisplayOrder;
                widgetInstance.Data = JsonConvert.SerializeObject(model.Setting);

                _widgetInstanceRepository.SaveChanges();
                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpGet("available-orderby")]
        public IActionResult GetAvailableOrderBy()
        {
            var model = EnumHelper.ToDictionary(typeof(ProductWidgetOrderBy)).Select(x => new { Id = x.Key.ToString(), Name = x.Value });
            return Json(model);
        }
    }
}
