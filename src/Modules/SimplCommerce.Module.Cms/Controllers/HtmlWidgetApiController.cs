using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Cms.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/html-widgets")]
    public class HtmlWidgetApiController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;

        public HtmlWidgetApiController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRespository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var widget = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new HtmlWidgetForm
            {
                Id = widget.Id,
                Name = widget.Name,
                WidgetZoneId = widget.WidgetZoneId,
                HtmlContent = widget.HtmlData
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] HtmlWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = 2,
                    WidgetZoneId = model.WidgetZoneId,
                    HtmlData = model.HtmlContent
                };

                _widgetInstanceRepository.Add(widgetInstance);
                _widgetInstanceRepository.SaveChange();
                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] HtmlWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
                widgetInstance.Name = model.Name;
                widgetInstance.WidgetZoneId = model.WidgetZoneId;
                widgetInstance.HtmlData = model.HtmlContent;

                _widgetInstanceRepository.SaveChange();
                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }
    }
}
