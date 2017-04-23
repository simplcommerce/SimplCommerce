using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CarouselWidgetApiController(IRepository<WidgetInstance> widgetInstanceRepository, 
            IRepository<Widget> widgetRespository, 
            IMediaService mediaService,
            IMapper mapper)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
            _mediaService = mediaService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
            
            var model = _mapper.Map<WidgetInstance, CarouselWidgetForm>(widgetInstance);

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
                
                var widgetInstance = _mapper.Map<CarouselWidgetForm, WidgetInstance>(model);
                widgetInstance.WidgetId = 1;

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
                var widgetInstanceForModification = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
                _mapper.Map(model, widgetInstanceForModification, op => op.BeforeMap((fModel, tWidgetInstanceForModification) =>   
                {
                    fModel.Id = tWidgetInstanceForModification.Id; 
                }));

                _widgetInstanceRepository.SaveChange();
                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        private CarouselWidgetForm ToCarouselWidgetFormModel(IFormCollection formCollection)
        {
            DateTimeOffset publishStart;
            DateTimeOffset publishEnd;
            var model = new CarouselWidgetForm();
            model.Name = formCollection["name"];
            model.WidgetZoneId = int.Parse(formCollection["widgetZoneId"]);
            if(DateTimeOffset.TryParse(formCollection["publishStart"], out publishStart))
            {
                model.PublishStart = publishStart;
            }

            if(DateTimeOffset.TryParse(formCollection["publishEnd"], out publishEnd))
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

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            _mediaService.SaveMedia(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}
