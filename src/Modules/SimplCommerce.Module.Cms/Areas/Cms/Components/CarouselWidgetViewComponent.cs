using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Cms.Areas.Cms.ViewModels;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Cms.Areas.Cms.Components
{
    public class CarouselWidgetViewComponent : ViewComponent
    {
        private readonly IMediaService _mediaService;
        private readonly IStringLocalizer _localizer;

        public CarouselWidgetViewComponent(IMediaService mediaService, IStringLocalizerFactory stringLocalizerFactory)
        {
            _mediaService = mediaService;
            _localizer = stringLocalizerFactory.Create(null);
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            if(widgetInstance == null)
            {
                throw new ArgumentNullException(nameof(widgetInstance));
            }

            var model = new CarouselWidgetViewComponentVm
            {
                Id = widgetInstance.Id,
                Items = JsonConvert.DeserializeObject<IList<CarouselWidgetViewComponentItemVm>>(widgetInstance.Data)
            };

            foreach (var item in model.Items)
            {
                item.Image = _mediaService.GetMediaUrl(item.Image);

                if (!string.IsNullOrWhiteSpace(item.Caption)) { item.Caption = _localizer.GetString(item.Caption); }
                if (!string.IsNullOrWhiteSpace(item.SubCaption)) { item.SubCaption = _localizer.GetString(item.SubCaption); }
                if (!string.IsNullOrWhiteSpace(item.LinkText)) { item.LinkText = _localizer.GetString(item.LinkText); }
            }

            return View(this.GetViewPath(), model);
        }
    }
}
