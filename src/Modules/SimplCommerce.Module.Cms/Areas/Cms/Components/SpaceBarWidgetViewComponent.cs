using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Cms.Areas.Cms.ViewModels;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Cms.Areas.Cms.Components
{
    public class SpaceBarWidgetViewComponent : ViewComponent
    {
        private readonly IMediaService _mediaService;
        private readonly IStringLocalizer _localizer;
        private readonly IContentLocalizationService _contentLocalizationService;

        public SpaceBarWidgetViewComponent(IMediaService mediaService, IStringLocalizerFactory stringLocalizerFactory, IContentLocalizationService contentLocalizationService)
        {
            _mediaService = mediaService;
            _localizer = stringLocalizerFactory.Create(null);
            _contentLocalizationService = contentLocalizationService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new SpaceBarWidgetComponentVm
            {
                Id = widgetInstance.Id,
                WidgetName = _contentLocalizationService.GetLocalizedProperty(nameof(WidgetInstance), widgetInstance.Id, nameof(widgetInstance.Name), widgetInstance.Name),
                Items = JsonConvert.DeserializeObject<List<SpaceBarWidgetSetting>>(widgetInstance.Data)
            };

            foreach (var item in model.Items)
            {
                if (!string.IsNullOrWhiteSpace(item.Title)) { item.Title = _localizer[item.Title]; }
                if (!string.IsNullOrWhiteSpace(item.Description)) { item.Description = _localizer[item.Description]; }

                if (!string.IsNullOrEmpty(item.Image))
                {
                    item.ImageUrl = _mediaService.GetMediaUrl(item.Image);
                }
            }

            return View(this.GetViewPath(), model);
        }
    }
}
