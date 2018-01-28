using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Get(long id)
        {
            var widget = await _widgetInstanceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            var model = new HtmlWidgetForm
            {
                Id = widget.Id,
                Name = widget.Name,
                WidgetZoneId = widget.WidgetZoneId,
                HtmlContent = widget.HtmlData,
                PublishStart = widget.PublishStart,
                PublishEnd = widget.PublishEnd,
                DisplayOrder = widget.DisplayOrder,
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HtmlWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = 2,
                    WidgetZoneId = model.WidgetZoneId,
                    HtmlData = model.HtmlContent,
                    PublishStart = model.PublishStart,
                    PublishEnd = model.PublishEnd,
                    DisplayOrder = model.DisplayOrder,
                };

                _widgetInstanceRepository.Add(widgetInstance);
                await _widgetInstanceRepository.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = widgetInstance.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] HtmlWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = await _widgetInstanceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                widgetInstance.Name = model.Name;
                widgetInstance.WidgetZoneId = model.WidgetZoneId;
                widgetInstance.HtmlData = model.HtmlContent;
                widgetInstance.PublishStart = model.PublishStart;
                widgetInstance.PublishEnd = model.PublishEnd;
                widgetInstance.DisplayOrder = model.DisplayOrder;

                await _widgetInstanceRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}
