using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.ProductRecentlyViewed.Data;

namespace SimplCommerce.Module.ProductRecentlyViewed.Areas.ProductRecentlyViewed.Components
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
        public async Task<IViewComponentResult> InvokeAsync(long? productId, int itemCount = 5)
        {
            var user = await _workContext.GetCurrentUser();
            IQueryable<Product> query = _productRepository.GetRecentlyViewedProduct(user.Id)
                .Include(x => x.ThumbnailImage);
            if (productId.HasValue)
            {
                query = query.Where(x => x.Id != productId.Value);
            }
            
            var model = query.Take(itemCount)
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
