using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Catalog.ViewModels;

namespace SimplCommerce.Module.Cms.Components
{
    public class HomeProductWidgetViewComponent : ViewComponent
    {
        
        private readonly IRepository<Product> _productRepository;
        private readonly IMediaService _mediaService;
        private readonly IProductPricingService _productPricingService;

        public HomeProductWidgetViewComponent(IRepository<Product> productRepository, IMediaService mediaService, IProductPricingService productPricingService)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _productPricingService = productPricingService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            List<Product> productlist = new List<Product>();
            var model = new HomeProductWidegtViewModel
            {
                Id = widgetInstance.Id,
                WidgetName = widgetInstance.Name,
                Settings = JsonConvert.DeserializeObject<HomeProductWidgetSetting>(widgetInstance.Data)
            };
            if (model == null)
            {
                return View();
            }
            foreach (var item in model.Settings.ProductIds)
            {
                var product = _productRepository.Query().Where(x => x.Id == Convert.ToInt64(item.ProductId)).FirstOrDefault();

                if (product != null)
                {
                    productlist.Add(product);
                  
                }
                
            }

            model.Products = productlist.OrderByDescending(x => x.CreatedOn)
                 .Take(model.Settings.NumberofProducts)
                 .Select(x => ProductThumbnail.FromProduct(x)).ToList();
            foreach (var product in model.Products)
            {
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
                product.CalculatedProductPrice = _productPricingService.CalculateProductPrice(product);
            }

            return View("/Modules/SimplCommerce.Module.Cms/Views/Components/HomeProductWidget.cshtml", model);
        }
    }
}
