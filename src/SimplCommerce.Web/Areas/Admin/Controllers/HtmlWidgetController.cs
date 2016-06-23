using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Cms;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class HtmlWidgetController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;

        public HtmlWidgetController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRespository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
        }

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
        public IActionResult Create([FromBody] HtmlWidgetForm model)
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

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] HtmlWidgetForm model)
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
