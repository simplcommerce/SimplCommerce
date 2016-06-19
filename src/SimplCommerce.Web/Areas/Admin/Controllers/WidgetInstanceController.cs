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
                .Select(x => new WidgetInstanceListItem
            {
                Id = x.Id,
                Name = x.Name,
                WidgetType = x.Widget.Name,
                WidgetZone = x.WidgetZone.ToString(),
                CreatedOn = x.CreatedOn,
                EditUrl = x.Widget.EditUrl,
                PublishStart = x.PublishStart,
                PublishEnd = x.PublishEnd
            }).ToList();

            return Json(widgetInstances);
        }
    }
}
