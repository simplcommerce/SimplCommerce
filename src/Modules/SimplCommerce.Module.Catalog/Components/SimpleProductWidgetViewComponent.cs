using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Catalog.Components
{
    public class SimpleProductWidgetViewComponent : ViewComponent
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMediaService _mediaService;
        private readonly IProductPricingService _productPricingService;

        public SimpleProductWidgetViewComponent(IRepository<Product> productRepository, IMediaService mediaService, IProductPricingService productPricingService)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _productPricingService = productPricingService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new SimpleProductWidgetComponentVm
            {
                Id = widgetInstance.Id,
                WidgetName = widgetInstance.Name,
                Setting = JsonConvert.DeserializeObject<SimpleProductWidgetSetting>(widgetInstance.Data)
            };

            foreach (var item in model.Setting.Products)
            {
                var product = _productRepository.Query().Where(x => x.Id == item.Id).FirstOrDefault();

                if (product != null)
                {
                    var productThumbnail = ProductThumbnail.FromProduct(product);
                    productThumbnail.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
                    productThumbnail.CalculatedProductPrice = _productPricingService.CalculateProductPrice(product);
                    model.Products.Add(productThumbnail);
                }
            }

            return View(this.GetViewPath(), model);
        }
    }
}
