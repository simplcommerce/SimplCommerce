using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Cms.Components
{
    public class SpaceBarWidgetViewComponent : ViewComponent
    {
        private IMediaService _mediaService;

        public SpaceBarWidgetViewComponent(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new SpaceBarWidgetComponentVm
            {
                Id = widgetInstance.Id,
                WidgetName = widgetInstance.Name,
                Items = JsonConvert.DeserializeObject<List<SpaceBarWidgetSetting>>(widgetInstance.Data)
            };

            foreach (var item in model.Items)
            {
                if (string.IsNullOrEmpty(item.Image))
                {
                    continue;
                }

                item.ImageUrl = _mediaService.GetMediaUrl(item.Image);
            }

            return View(this.GetViewPath(), model);
        }
    }
}
