using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Core.Controllers
{
    public class HomeController : Controller
    {
        private IWidgetInstanceService _widgetInstanceService;

        public HomeController(IWidgetInstanceService widgetInstanceService)
        {
            _widgetInstanceService = widgetInstanceService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            model.WidgetInstances = _widgetInstanceService.GetPublished().Select(x => new WidgetInstanceViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ViewComponentName = x.Widget.ViewComponentName,
                WidgetId = x.WidgetId,
                WidgetZoneId = x.WidgetZoneId,
                Data = x.Data,
                HtmlData = x.HtmlData
            }).ToList();

            return View(model);
        }
    }
}
