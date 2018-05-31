using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.ProductRecentlyViewed.Data;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.ProductRecentlyViewed.Components
{
    public class ProductRecentlyViewedViewComponent : ViewComponent
    {
        private readonly IRecentlyViewedProductRepository _productRepository;
        private readonly IMediaService _mediaService;
        private readonly IProductPricingService _productPricingService;
        private readonly IWorkContext _workContext;

        public ProductRecentlyViewedViewComponent(IRecentlyViewedProductRepository productRepository, IMediaService mediaService, IProductPricingService productPricingService, IWorkContext workContext)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _productPricingService = productPricingService;
            _workContext = workContext;
        }

        // TODO Number of items to config
        public IViewComponentResult Invoke(long? productId)
        {
            var user = _workContext.GetCurrentUser().Result;
            IQueryable<Product> query = _productRepository.GetRecentlyViewedProduct(user.Id)
                .Include(x => x.ThumbnailImage);
            if (productId.HasValue)
            {
                query = query.Where(x => x.Id != productId.Value);
            }
            
            var model = query.Take(5)
                .Select(x => ProductThumbnail.FromProduct(x)).ToList();

            foreach (var product in model)
            {
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
                product.CalculatedProductPrice = _productPricingService.CalculateProductPrice(product);
            }

            return View(this.GetViewPath(), model);
        }
    }
}
