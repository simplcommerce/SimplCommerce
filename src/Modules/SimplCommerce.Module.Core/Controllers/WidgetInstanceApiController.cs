using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/widget-instances")]
    public class WidgetInstanceApiController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;

        public WidgetInstanceApiController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRespository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var widgetInstances = _widgetInstanceRepository.Query()
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    WidgetType = x.Widget.Name,
                    WidgetZone = x.WidgetZone.Name,
                    CreatedOn = x.CreatedOn,
                    EditUrl = x.Widget.EditUrl,
                    PublishStart = x.PublishStart,
                    PublishEnd = x.PublishEnd
                }).ToList();

            return Json(widgetInstances);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            if (widgetInstance == null)
            {
                return NotFound();
            }

            _widgetInstanceRepository.Remove(widgetInstance);
            _widgetInstanceRepository.SaveChange();

            return Ok();
        }
    }
}
