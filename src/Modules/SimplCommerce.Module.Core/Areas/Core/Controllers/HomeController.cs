using System;
using System.Linq;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IWidgetInstanceService _widgetInstanceService;
        private readonly IContentLocalizationService _contentLocalizationService;

        public HomeController(ILoggerFactory factory, IWidgetInstanceService widgetInstanceService, IContentLocalizationService contentLocalizationService)
        {
            _logger = factory.CreateLogger("Unhandled Error");
            _widgetInstanceService = widgetInstanceService;
            _contentLocalizationService = contentLocalizationService;
        }

        public IActionResult TestError()
        {
            throw new Exception("Test behavior in case of error");
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            var getWidgetInstanceTranslations = _contentLocalizationService.GetLocalizationFunction<WidgetInstance>();

            model.WidgetInstances = _widgetInstanceService.GetPublished()
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new WidgetInstanceViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ViewComponentName = x.Widget.ViewComponentName,
                WidgetId = x.WidgetId,
                WidgetZoneId = x.WidgetZoneId,
                Data = x.Data,
                HtmlData = x.HtmlData
            }).ToList();

            foreach(var item in model.WidgetInstances)
            {
                item.Name = getWidgetInstanceTranslations(item.Id, nameof(item.Name), item.Name);
                item.HtmlData = getWidgetInstanceTranslations(item.Id, nameof(item.HtmlData), item.HtmlData);
            }

            return View(model);
        }

        [HttpGet("/Home/ErrorWithCode/{statusCode}")]
        public IActionResult ErrorWithCode(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("404");
            }

            return View("Error");
        }

        [HttpGet("/Home/Error")]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;

            if (error != null)
            {
                _logger.LogError(error.Message, error);
            }

            return View("Error");
        }
    }
}
