using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.ViewModels;
using SimplCommerce.Web.ViewModels.Catalog;

namespace SimplCommerce.Web.Components
{
    public class ProductDisplayWidgetViewComponent : ViewComponent
    {
        private IRepository<Product> _productRepository;
        private IMediaService _mediaService;

        public ProductDisplayWidgetViewComponent(IRepository<Product> productRepository, IMediaService mediaService)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceVm widgetInstance)
        {
            var model = new ProductDisplayWidgetViewComponentVm
            {
                Id = widgetInstance.Id,
                WidgetName = widgetInstance.Name,
                Setting = JsonConvert.DeserializeObject<WidgetProductDisplaySetting>(widgetInstance.Data)
            };

            var query = _productRepository.Query()
              .Where(x => x.IsPublished && x.IsVisibleIndividually);

            if(model.Setting.FeaturedOnly)
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

            return View(model);
        }
    }
}
