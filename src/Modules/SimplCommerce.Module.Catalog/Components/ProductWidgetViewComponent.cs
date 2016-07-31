using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Catalog.Components
{
    public class ProductWidgetViewComponent : ViewComponent
    {
        private IRepository<Product> _productRepository;
        private IMediaService _mediaService;

        public ProductWidgetViewComponent(IRepository<Product> productRepository, IMediaService mediaService)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new ProductWidgetComponentVm
            {
                Id = widgetInstance.Id,
                WidgetName = widgetInstance.Name,
                Setting = JsonConvert.DeserializeObject<ProductWidgetSetting>(widgetInstance.Data)
            };

            var query = _productRepository.Query()
              .Where(x => x.IsPublished && x.IsVisibleIndividually);

            if (model.Setting.FeaturedOnly)
            {
                query = query.Where(x => x.IsFeatured);
            }

            model.Products = query
              .OrderByDescending(x => x.CreatedOn)
              .Take(model.Setting.NumberOfProducts)
              .Select(x => new ProductThumbnail
              {
                  Id = x.Id,
                  Name = x.Name,
                  SeoTitle = x.SeoTitle,
                  Price = x.Price,
                  OldPrice = x.OldPrice,
                  ThumbnailImage = x.ThumbnailImage,
                  NumberVariation = x.ProductLinks.Count
              }).ToList();

            foreach (var product in model.Products)
            {
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
            }

            return View("/Modules/SimplCommerce.Module.Catalog/Views/Components/ProductWidget.cshtml", model);
        }
    }
}
