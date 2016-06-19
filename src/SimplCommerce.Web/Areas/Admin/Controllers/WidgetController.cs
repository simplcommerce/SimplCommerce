using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using Microsoft.AspNetCore.Authorization;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class WidgetController : Controller
    {
        private readonly IRepository<Widget> _widgetRespository;

        public WidgetController(IRepository<Widget> widgetRespository)
        {
            _widgetRespository = widgetRespository;
        }

        public IActionResult List()
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
