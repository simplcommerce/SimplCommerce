using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMediaService _mediaService;

        public CarouselWidgetApiController(IRepository<WidgetInstance> widgetInstanceRepository, IMediaService mediaService)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _mediaService = mediaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var totalWidgets = _widgetInstanceRepository.Query().ToList().Count();
            var widgetInstance = await _widgetInstanceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            var model = new CarouselWidgetForm
            {
                Id = widgetInstance.Id,
                Name = widgetInstance.Name,
                WidgetZoneId = widgetInstance.WidgetZoneId,
                PublishStart = widgetInstance.PublishStart,
                PublishEnd = widgetInstance.PublishEnd,
                DisplayOrder = widgetInstance.DisplayOrder,
                Items = JsonConvert.DeserializeObject<IList<CarouselWidgetItemForm>>(widgetInstance.Data)
            };

            foreach (var item in model.Items)
            {
                item.ImageUrl = _mediaService.GetMediaUrl(item.Image);
            }

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormCollection formCollection)
        {
            var model = ToCarouselWidgetFormModel(formCollection);
            if (ModelState.IsValid)
            {
                foreach (var item in model.Items)
                {
                    item.Image = await SaveFile(item.UploadImage);
                }

                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = "CarouselWidget",
                    WidgetZoneId = model.WidgetZoneId,
                    PublishStart = model.PublishStart,
                    PublishEnd = model.PublishEnd,
                    DisplayOrder = model.DisplayOrder,
                    Data = JsonConvert.SerializeObject(model.Items)
                };

                _widgetInstanceRepository.Add(widgetInstance);
                await _widgetInstanceRepository.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = widgetInstance.Id }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, IFormCollection formCollection)
        {
            var model = ToCarouselWidgetFormModel(formCollection);

            foreach (var item in model.Items)
            {
                if (item.UploadImage != null)
                {
                    if (!string.IsNullOrWhiteSpace(item.Image))
                    {
                        await _mediaService.DeleteMediaAsync(item.Image);
                    }
                    item.Image = await SaveFile(item.UploadImage);
                }
            }

            if (ModelState.IsValid)
            {
                var widgetInstance = await _widgetInstanceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if(widgetInstance == null)
                {
                    return NotFound();
                }

                widgetInstance.Name = model.Name;
                widgetInstance.PublishStart = model.PublishStart;
                widgetInstance.PublishEnd = model.PublishEnd;
                widgetInstance.WidgetZoneId = model.WidgetZoneId;
                widgetInstance.DisplayOrder = model.DisplayOrder;
                widgetInstance.Data = JsonConvert.SerializeObject(model.Items);

                await _widgetInstanceRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        private CarouselWidgetForm ToCarouselWidgetFormModel(IFormCollection formCollection)
        {
            var model = new CarouselWidgetForm();
            model.Name = formCollection["name"];
            model.WidgetZoneId = int.Parse(formCollection["widgetZoneId"]);
            int.TryParse(formCollection["displayOrder"], out int displayOrder);
            model.DisplayOrder = displayOrder;
            if (DateTimeOffset.TryParse(formCollection["publishStart"], out DateTimeOffset publishStart))
            {
                model.PublishStart = publishStart;
            }

            if(DateTimeOffset.TryParse(formCollection["publishEnd"], out DateTimeOffset publishEnd))
            {
                model.PublishEnd = publishEnd;
            }

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

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}
