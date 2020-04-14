using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.ProductsRecommendation.Models;

namespace SimplCommerce.Module.ProductsRecommendation.Areas.ProductsRecommendation.Components
{
    public class RecommendedProductsViewComponent : ViewComponent
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMediaService _mediaService;
        private readonly IProductPricingService _productPricingService;
        private readonly IWorkContext _workContext;
        private readonly IContentLocalizationService _contentLocalizationService;
        private readonly IRecommendationService _recommendationService;

        public RecommendedProductsViewComponent(
            IRepository<Product> productRepository,
            IMediaService mediaService,
            IProductPricingService productPricingService,
            IContentLocalizationService contentLocalizationService,
            IWorkContext workContext,
            IRecommendationService recommendationService)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _productPricingService = productPricingService;
            _contentLocalizationService = contentLocalizationService;
            _workContext = workContext;
            _recommendationService = recommendationService;
        }

        // TODO Number of items to config
        public async Task<IViewComponentResult> InvokeAsync(long? productId, int itemCount = 4)
        {
            IList<ProductThumbnail> RecommendProducts = new List<ProductThumbnail>();

            var topItems = (from m in _productRepository.Query().Where(x => x.IsPublished && x.IsVisibleIndividually && x.Id != productId)
                                                            .Include(x => x.OptionValues)
                                                            .Include(x => x.ThumbnailImage)
                                                            .Include(x => x.Medias).ThenInclude(m => m.Media)
                                                            .AsEnumerable()
                            let p = _recommendationService.Predict(
                               new ProductInfo()
                               {
                                   ProductID = (float)productId,
                                   CombinedProductID = (uint)m.Id
                               })
                            orderby p.Score descending
                            select (Product: m, Score: p.Score)).Take(itemCount);

            foreach (var item in topItems)
            {
                var productThumbnail = ProductThumbnail.FromProduct(item.Product);
                productThumbnail.Name = _contentLocalizationService.GetLocalizedProperty(nameof(Product), productThumbnail.Id, nameof(productThumbnail.Name), productThumbnail.Name);
                productThumbnail.ThumbnailUrl = _mediaService.GetThumbnailUrl(productThumbnail.ThumbnailImage);
                productThumbnail.CalculatedProductPrice = _productPricingService.CalculateProductPrice(productThumbnail);
                RecommendProducts.Add(productThumbnail);
            }
            return View(this.GetViewPath(), RecommendProducts);
        }
    }
}
