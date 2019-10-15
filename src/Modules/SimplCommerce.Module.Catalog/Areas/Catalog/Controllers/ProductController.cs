using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IMediator _mediator;
        private readonly IProductPricingService _productPricingService;
        private readonly IContentLocalizationService _contentLocalizationService;

        public ProductController(IRepository<Product> productRepository,
            IMediaService mediaService,
            IMediator mediator,
            IProductPricingService productPricingService,
            IContentLocalizationService contentLocalizationService)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _mediator = mediator;
            _productPricingService = productPricingService;
            _contentLocalizationService = contentLocalizationService;
        }

        [HttpGet("product/product-overview")]
        public async Task<IActionResult> ProductOverview(long id)
        {
            var product = await _productRepository.Query()
                .Include(x => x.OptionValues)
                .Include(x => x.ProductLinks).ThenInclude(p => p.LinkedProduct)
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsPublished);

            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductDetail
            {
                Id = product.Id,
                Name = _contentLocalizationService.GetLocalizedProperty(product, nameof(product.Name), product.Name),
                CalculatedProductPrice = _productPricingService.CalculateProductPrice(product),
                IsCallForPricing = product.IsCallForPricing,
                IsAllowToOrder = product.IsAllowToOrder,
                StockTrackingIsEnabled = product.StockTrackingIsEnabled,
                StockQuantity = product.StockQuantity,
                ShortDescription = _contentLocalizationService.GetLocalizedProperty(product, nameof(product.ShortDescription), product.ShortDescription),
                ReviewsCount = product.ReviewsCount,
                RatingAverage = product.RatingAverage,
            };

            MapProductVariantToProductVm(product, model);
            MapProductOptionToProductVm(product, model);
            MapProductImagesToProductVm(product, model);

            return PartialView(model);
        }

        public async Task<IActionResult> ProductDetail(long id)
        {
            var product = _productRepository.Query()
                .Include(x => x.OptionValues)
                .Include(x => x.Categories).ThenInclude(c => c.Category)
                .Include(x => x.AttributeValues).ThenInclude(a => a.Attribute)
                .Include(x => x.ProductLinks).ThenInclude(p => p.LinkedProduct).ThenInclude(m => m.ThumbnailImage)
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .Include(x => x.Brand)
                .FirstOrDefault(x => x.Id == id && x.IsPublished);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductDetail
            {
                Id = product.Id,
                Name = _contentLocalizationService.GetLocalizedProperty(product, nameof(product.Name), product.Name),
                Brand = product.Brand,
                CalculatedProductPrice = _productPricingService.CalculateProductPrice(product),
                IsCallForPricing = product.IsCallForPricing,
                IsAllowToOrder = product.IsAllowToOrder,
                StockTrackingIsEnabled = product.StockTrackingIsEnabled,
                StockQuantity = product.StockQuantity,
                ShortDescription = _contentLocalizationService.GetLocalizedProperty(product, nameof(product.ShortDescription), product.ShortDescription),
                MetaTitle = product.MetaTitle,
                MetaKeywords = product.MetaKeywords,
                MetaDescription = product.MetaDescription,
                Description = _contentLocalizationService.GetLocalizedProperty(product, nameof(product.Description), product.Description),
                Specification = _contentLocalizationService.GetLocalizedProperty(product, nameof(product.Specification), product.Specification),
                ReviewsCount = product.ReviewsCount,
                RatingAverage = product.RatingAverage,
                Attributes = product.AttributeValues.Select(x => new ProductDetailAttribute { Name = x.Attribute.Name, Value = x.Value }).ToList(),
                Categories = product.Categories.Select(x => new ProductDetailCategory { Id = x.CategoryId, Name = x.Category.Name, Slug = x.Category.Slug }).ToList()
            };

            MapProductVariantToProductVm(product, model);
            MapRelatedProductToProductVm(product, model);
            MapProductOptionToProductVm(product, model);
            MapProductImagesToProductVm(product, model);

            await _mediator.Publish(new EntityViewed { EntityId = product.Id, EntityTypeId = "Product" });
            _productRepository.SaveChanges();

            return View(model);
        }

        private void MapProductImagesToProductVm(Product product, ProductDetail model)
        {
            model.Images = product.Medias.Where(x => x.Media.MediaType == Core.Models.MediaType.Image).Select(productMedia => new MediaViewModel
            {
                Url = _mediaService.GetMediaUrl(productMedia.Media),
                ThumbnailUrl = _mediaService.GetThumbnailUrl(productMedia.Media)
            }).ToList();
        }

        private void MapProductOptionToProductVm(Product product, ProductDetail model)
        {
            foreach (var item in product.OptionValues)
            {
                var optionValues = JsonConvert.DeserializeObject<IList<ProductOptionValueVm>>(item.Value);
                foreach (var value in optionValues)
                {
                    if (!model.OptionDisplayValues.ContainsKey(value.Key))
                    {
                        model.OptionDisplayValues.Add(value.Key, new ProductOptionDisplay { DisplayType = item.DisplayType, Value = value.Display });
                    }
                }
            }
        }

        private void MapProductVariantToProductVm(Product product, ProductDetail model)
        {
            if(!product.ProductLinks.Any(x => x.LinkType == ProductLinkType.Super))
            {
                return;
            }

            var variations = _productRepository
                .Query()
                .Include(x => x.OptionCombinations).ThenInclude(o => o.Option)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .Where(x => x.LinkedProductLinks.Any(link => link.ProductId == product.Id && link.LinkType == ProductLinkType.Super))
                .Where(x => x.IsPublished)
                .ToList();

            foreach (var variation in variations)
            {
                var variationVm = new ProductDetailVariation
                {
                    Id = variation.Id,
                    Name = variation.Name,
                    NormalizedName = variation.NormalizedName,
                    IsAllowToOrder = variation.IsAllowToOrder,
                    IsCallForPricing = variation.IsCallForPricing,
                    StockTrackingIsEnabled = variation.StockTrackingIsEnabled,
                    StockQuantity = variation.StockQuantity,
                    CalculatedProductPrice = _productPricingService.CalculateProductPrice(variation),
                    Images = variation.Medias.Where(x => x.Media.MediaType == Core.Models.MediaType.Image).Select(productMedia => new MediaViewModel
                    {
                        Url = _mediaService.GetMediaUrl(productMedia.Media),
                        ThumbnailUrl = _mediaService.GetThumbnailUrl(productMedia.Media)
                    }).ToList()
                };

                var optionCombinations = variation.OptionCombinations.OrderBy(x => x.SortIndex);
                foreach (var combination in optionCombinations)
                {
                    variationVm.Options.Add(new ProductDetailVariationOption
                    {
                        OptionId = combination.OptionId,
                        OptionName = combination.Option.Name,
                        Value = combination.Value
                    });
                }

                model.Variations.Add(variationVm);
            }
        }

        private void MapRelatedProductToProductVm(Product product, ProductDetail model)
        {
            var publishedProductLinks = product.ProductLinks.Where(x => x.LinkedProduct.IsPublished && (x.LinkType == ProductLinkType.Related || x.LinkType == ProductLinkType.CrossSell));
            foreach (var productLink in publishedProductLinks)
            {
                var linkedProduct = productLink.LinkedProduct;
                var productThumbnail = ProductThumbnail.FromProduct(linkedProduct);
                productThumbnail.Name = _contentLocalizationService.GetLocalizedProperty(nameof(Product), productThumbnail.Id, nameof(product.Name), productThumbnail.Name);
                productThumbnail.ThumbnailUrl = _mediaService.GetThumbnailUrl(linkedProduct.ThumbnailImage);
                productThumbnail.CalculatedProductPrice = _productPricingService.CalculateProductPrice(linkedProduct);

                if (productLink.LinkType == ProductLinkType.Related)
                {
                    model.RelatedProducts.Add(productThumbnail);
                }

                if (productLink.LinkType == ProductLinkType.CrossSell)
                {
                    model.CrossSellProducts.Add(productThumbnail);
                }
            }
        }
    }
}
