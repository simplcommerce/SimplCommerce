using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Cms;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class WidgetInstanceController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;

        public WidgetInstanceController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRespository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
        }

        public IActionResult List()
        {
            var widgetInstances = _widgetInstanceRepository.Query()
                .Include(x => x.Widget)
                .Include(x => x.WidgetZone)
                .Select(x => new WidgetInstanceListItem
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

        public IActionResult Delete(long id)
        {
            var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            if(widgetInstance == null)
            {
                return NotFound();
            }

            _widgetInstanceRepository.Remove(widgetInstance);
            _widgetInstanceRepository.SaveChange();

            return Ok();
        }
    }
}
