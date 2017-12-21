using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Cms.Components
{
    public class SpaceBarWidgetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new SpaceBarWidgetComponentVm
            {
                Id = widgetInstance.Id,
                WidgetName = widgetInstance.Name,
                Items = JsonConvert.DeserializeObject<List<SpaceBarWidgetSetting>>(widgetInstance.Data)
            };
            return View("/Modules/SimplCommerce.Module.Cms/Views/Components/SpaceBarWidget.cshtml", model);
        }
    }
}
