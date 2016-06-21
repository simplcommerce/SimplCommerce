using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Cms;
using Newtonsoft.Json;
using System.Collections.Generic;
using SimplCommerce.Core.ApplicationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CarouselWidgetController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;
        private readonly IMediaService _mediaService;

        public CarouselWidgetController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRespository, IMediaService mediaService)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
            _mediaService = mediaService;
        }

        public IActionResult Get(long id)
        {
            var widget = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new CarouselWidgetForm
            {
                Id = widget.Id,
                Name = widget.Name,
                Zone = (int)widget.WidgetZone,
                Items = JsonConvert.DeserializeObject<IList<CarouselWidgetItemForm>>(widget.WidgetData)
            };

            foreach(var item in model.Items)
            {
                item.ImageUrl = _mediaService.GetMediaUrl(item.Image);
            }

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create(IFormCollection formCollection)
        {
            var model = ToCarouselWidgetFormModel(formCollection);
            if (ModelState.IsValid)
            {
                foreach(var item in model.Items)
                {
                    item.Image = SaveFile(item.UploadImage);
                }

                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = 1,
                    WidgetZone = (WidgetZone)model.Zone,
                    WidgetData = JsonConvert.SerializeObject(model.Items)
                };

                _widgetInstanceRepository.Add(widgetInstance);
                _widgetInstanceRepository.SaveChange();
                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Edit(long id, IFormCollection formCollection)
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
                widgetInstance.WidgetZone = (WidgetZone)model.Zone;
                widgetInstance.WidgetData = JsonConvert.SerializeObject(model.Items);

                _widgetInstanceRepository.SaveChange();
                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        private CarouselWidgetForm ToCarouselWidgetFormModel(IFormCollection formCollection)
        {
            var model = new CarouselWidgetForm();
            model.Name = formCollection["name"];
            model.Zone = int.Parse(formCollection["zone"]);
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
