using System;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Catalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IMediator _mediator;
        private readonly IProductPricingService _productPricingService;

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService, IMediator mediator, IProductPricingService productPricingService)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _mediator = mediator;
            _productPricingService = productPricingService;
        }

        public IActionResult ProductDetail(long id)
        {
            var product = _productRepository.Query()
                .Include(x => x.Categories).ThenInclude(c => c.Category)
                .Include(x => x.AttributeValues).ThenInclude(a => a.Attribute)
                .Include(x => x.ProductLinks).ThenInclude(p => p.LinkedProduct).ThenInclude(m => m.ThumbnailImage)
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .FirstOrDefault(x => x.Id == id && x.IsPublished);
            if (product == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new ProductDetail
            {
                Id = product.Id,
                Name = product.Name,
                CalculatedProductPrice = _productPricingService.CalculateProductPrice(product),
                IsCallForPricing = product.IsCallForPricing,
                IsAllowToOrder = product.IsAllowToOrder,
                StockQuantity = product.StockQuantity,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Specification = product.Specification,
                ReviewsCount = product.ReviewsCount,
                RatingAverage = product.RatingAverage,
                Attributes = product.AttributeValues.Select(x => new ProductDetailAttribute { Name = x.Attribute.Name, Value = x.Value }).ToList(),
                Categories = product.Categories.Select(x => new ProductDetailCategory { Id = x.CategoryId, Name = x.Category.Name, SeoTitle = x.Category.SeoTitle }).ToList()
            };

            MapProductVariantToProductVm(product, model);
            MapRelatedProductToProductVm(product, model);

            model.Images = product.Medias.Where(x => x.Media.MediaType == Core.Models.MediaType.Image).Select(productMedia => new MediaViewModel
            {
                Url = _mediaService.GetMediaUrl(productMedia.Media),
                ThumbnailUrl = _mediaService.GetThumbnailUrl(productMedia.Media)
            }).ToList();

            _mediator.Publish(new ActivityHappened {ActivityTypeId = 1, EntityId = product.Id, EntityTypeId = 3, TimeHappened = DateTimeOffset.Now});
            _productRepository.SaveChange();

            return View(model);
        }

        private void MapProductVariantToProductVm(Product product, ProductDetail model)
        {
            var variations = _productRepository
                .Query()
                .Include(x => x.OptionCombinations).ThenInclude(o => o.Option)
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
                    StockQuantity = variation.StockQuantity,
                    CalculatedProductPrice = _productPricingService.CalculateProductPrice(variation)
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
            foreach(var productLink in product.ProductLinks.Where(x => x.LinkType == ProductLinkType.Relation))
            {
                var relatedProduct = productLink.LinkedProduct;
                var productThumbnail = new ProductThumbnail
                {
                    Id = relatedProduct.Id,
                    Name = relatedProduct.Name,
                    SeoTitle = relatedProduct.SeoTitle,
                    Price = relatedProduct.Price,
                    OldPrice = relatedProduct.OldPrice,
                    SpecialPrice = relatedProduct.SpecialPrice,
                    SpecialPriceStart = relatedProduct.SpecialPriceStart,
                    SpecialPriceEnd = relatedProduct.SpecialPriceEnd,
                    StockQuantity = relatedProduct.StockQuantity,
                    IsAllowToOrder = relatedProduct.IsAllowToOrder,
                    IsCallForPricing = relatedProduct.IsCallForPricing,
                    ThumbnailImage = relatedProduct.ThumbnailImage,
                    NumberVariation = relatedProduct.ProductLinks.Count,
                    ReviewsCount = relatedProduct.ReviewsCount,
                    RatingAverage = relatedProduct.RatingAverage
                };

                productThumbnail.ThumbnailUrl = _mediaService.GetThumbnailUrl(relatedProduct.ThumbnailImage);
                productThumbnail.CalculatedProductPrice = _productPricingService.CalculateProductPrice(relatedProduct);

                model.RelatedProducts.Add(productThumbnail);
            }
        }
    }
}
