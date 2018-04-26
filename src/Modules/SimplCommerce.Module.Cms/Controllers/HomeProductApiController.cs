
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Cms.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/homeproduct-widgets")]
    public class HomeProductApiController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;
        private const int widgetid = 7;
        public HomeProductApiController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRepository, IMediaService mediaService)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new HomeProductWidegtForm
            {
                Id = widgetInstance.Id,
                Name = widgetInstance.Name,
                WidgetZoneId = widgetInstance.WidgetZoneId,
                PublishStart = widgetInstance.PublishStart,
                PublishEnd = widgetInstance.PublishEnd,
                DisplayOrder = widgetInstance.DisplayOrder,
                Settings = JsonConvert.DeserializeObject<HomeProductWidgetSetting>(widgetInstance.Data)
            };
           
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormCollection formCollection)
        {
            var model = ProductFormWidgetFormModel(formCollection);
            if (ModelState.IsValid)
            {
                

                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = widgetid,
                    WidgetZoneId = model.WidgetZoneId,
                    PublishStart = model.PublishStart,
                    PublishEnd = model.PublishEnd,
                    DisplayOrder = model.DisplayOrder,
                    Data = JsonConvert.SerializeObject(model.Settings)
                };

                _widgetInstanceRepository.Add(widgetInstance);
                _widgetInstanceRepository.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = widgetInstance.Id }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, IFormCollection formCollection)
        {
            var model = ProductFormWidgetFormModel(formCollection);

            if (ModelState.IsValid)
            {
                var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
                widgetInstance.Name = model.Name;
                widgetInstance.PublishStart = model.PublishStart;
                widgetInstance.PublishEnd = model.PublishEnd;
                widgetInstance.WidgetZoneId = model.WidgetZoneId;
                widgetInstance.DisplayOrder = model.DisplayOrder;
                widgetInstance.Data = JsonConvert.SerializeObject(model.Settings);
                _widgetInstanceRepository.SaveChanges();
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        private HomeProductWidegtForm ProductFormWidgetFormModel(IFormCollection formCollection)
        {
      
            var model = new HomeProductWidegtForm();
            var submodel = new HomeProductWidgetSetting();
            model.Name = formCollection["name"];
            submodel.NumberofProducts = Convert.ToInt16(formCollection[$"settings[numberofProducts]"]);
            model.WidgetZoneId = int.Parse(formCollection["widgetZoneId"]);
            int.TryParse(formCollection["displayOrder"], out int displayOrder);
            model.DisplayOrder = displayOrder;
            if (DateTimeOffset.TryParse(formCollection["publishStart"], out DateTimeOffset publishStart))
            {
                model.PublishStart = publishStart;
            }

            if (DateTimeOffset.TryParse(formCollection["publishEnd"], out DateTimeOffset publishEnd))
            {
                model.PublishEnd = publishEnd;
            }

            int numberOfItems = int.Parse(formCollection["numberOfItems"]);
            for (var i = 0; i < numberOfItems; i++)
            {
                var productId = formCollection[$"settings[productIds][{i}][productId]"];
               
                submodel.ProductIds.Add(new Pname { ProductId = productId});
            }
            model.Settings = submodel;
            return model;
        }

    }
}
