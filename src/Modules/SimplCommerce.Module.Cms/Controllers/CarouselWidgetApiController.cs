using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Cms.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/carousel-widgets")]
    public class CarouselWidgetApiController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;
        private readonly IMediaService _mediaService;

        public CarouselWidgetApiController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRespository, IMediaService mediaService)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
            _mediaService = mediaService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new CarouselWidgetForm
            {
                Id = widgetInstance.Id,
                Name = widgetInstance.Name,
                WidgetZoneId = widgetInstance.WidgetZoneId,
                Items = JsonConvert.DeserializeObject<IList<CarouselWidgetItemForm>>(widgetInstance.Data)
            };

            foreach (var item in model.Items)
            {
                item.ImageUrl = _mediaService.GetMediaUrl(item.Image);
            }

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post(IFormCollection formCollection)
        {
            var model = ToCarouselWidgetFormModel(formCollection);
            if (ModelState.IsValid)
            {
                foreach (var item in model.Items)
                {
                    item.Image = SaveFile(item.UploadImage);
                }

                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = 1,
                    WidgetZoneId = model.WidgetZoneId,
                    Data = JsonConvert.SerializeObject(model.Items)
                };

                _widgetInstanceRepository.Add(widgetInstance);
                _widgetInstanceRepository.SaveChange();
                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, IFormCollection formCollection)
        {
            var model = ToCarouselWidgetFormModel(formCollection);

            foreach (var item in model.Items)
            {
                if (item.UploadImage != null)
                {
                    if (!string.IsNullOrWhiteSpace(item.Image))
                    {
                        _mediaService.DeleteMedia(item.Image);
                    }
                    item.Image = SaveFile(item.UploadImage);
                }
            }

            if (ModelState.IsValid)
            {
                var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
                widgetInstance.Name = model.Name;
                widgetInstance.WidgetZoneId = model.WidgetZoneId;
                widgetInstance.Data = JsonConvert.SerializeObject(model.Items);

                _widgetInstanceRepository.SaveChange();
                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        private CarouselWidgetForm ToCarouselWidgetFormModel(IFormCollection formCollection)
        {
            var model = new CarouselWidgetForm();
            model.Name = formCollection["name"];
            model.WidgetZoneId = int.Parse(formCollection["widgetZoneId"]);
            int numberOfItems = int.Parse(formCollection["numberOfItems"]);
            for (var i = 0; i < numberOfItems; i++)
            {
                var item = new CarouselWidgetItemForm();
                item.Caption = formCollection[$"items[{i}][caption]"];
                item.TargetUrl = formCollection[$"items[{i}][targetUrl]"];
                item.Image = formCollection[$"items[{i}][image]"];
                item.UploadImage = formCollection.Files[$"items[{i}][uploadImage]"];
                model.Items.Add(item);
            }

            return model;
        }

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            _mediaService.SaveMedia(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}
