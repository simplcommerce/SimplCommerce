using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/widgets")]
    public class WidgetApiController : Controller
    {
        private readonly IRepository<Widget> _widgetRespository;

        public WidgetApiController(IRepository<Widget> widgetRespository)
        {
            _widgetRespository = widgetRespository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var widgets = _widgetRespository.Query().Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                CreateUrl = x.CreateUrl
            }).ToList();

            return Json(widgets);
        }
    }
}
