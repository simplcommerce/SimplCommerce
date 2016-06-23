using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class WidgetZoneController : Controller
    {
        private readonly IRepository<WidgetZone> _widgetZoneRespository;

        public WidgetZoneController(IRepository<WidgetZone> widgetZoneRespository)
        {
            _widgetZoneRespository = widgetZoneRespository;
        }

        public IActionResult List()
        {
            var widgetZones = _widgetZoneRespository.Query().Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return Json(widgetZones);
        }
    }
}
