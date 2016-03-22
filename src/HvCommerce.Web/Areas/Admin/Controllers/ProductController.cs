using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.Areas.Admin.ViewModels.Products;
using HvCommerce.Web.Areas.Admin.ViewModels.SmartTable;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using HvCommerce.Web.Extensions;

namespace HvCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMediaService mediaService;
        private readonly IUrlSlugService urlSlugService;

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService, IUrlSlugService urlSlugService)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
            this.urlSlugService = urlSlugService;
        }

        public IActionResult List([FromBody] SmartTableParam param)
        {
            var products = productRepository.Query().Where(x => !x.IsDeleted);
            var gridData = products.ToSmartTableResult(
                param,
                x => new ProductListItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CreatedOn = x.CreatedOn,
                        IsPublished = x.IsPublished
                    });

            return Json(gridData);
        }

        [HttpPost]
        public IActionResult Create(ProductForm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState.ToDictionary());
            }

            var product = new Product
            {
                Name = model.Product.Name,
                SeoTitle = StringHelper.ToUrlFriendly(model.Product.Name),
                ShortDescription = model.Product.ShortDescription,
                Description = model.Product.Description,
                Specification = model.Product.Specification,
                Price = model.Product.Price,
                OldPrice = model.Product.OldPrice,
                IsPublished = model.Product.IsPublished
            };

            foreach (var attribute in model.Product.Attributes)
            {
                foreach (var value in attribute.Values)
                {
                    product.AddAttributeValue(new ProductAttributeValue
                    {
                        Value = value,
                        AttributeId = attribute.Id
                    });
                }
            }

            MapProductVariationVmToProduct(model, product);

            foreach (var categoryId in model.Product.CategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };
                product.AddCategory(productCategory);
            }

            SaveProductImages(model, product);

            productRepository.Add(product);
            productRepository.SaveChange();

            urlSlugService.Add(product.SeoTitle, product.Id, "Product");
            productRepository.SaveChange();

            return Ok();
        }

        private static void MapProductVariationVmToProduct(ProductForm model, Product product)
        {
            foreach (var variationVm in model.Product.Variations)
            {
                var variation = new ProductVariation
                {
                    Name = variationVm.Name,
                    PriceOffset = variationVm.PriceOffset
                };
                foreach (var combinationVm in variationVm.AttributeCombinations)
                {
                    variation.AddAttributeCombination(new ProductAttributeCombination
                    {
                        AttributeId = combinationVm.AttributeId,
                        Value = combinationVm.Value
                    });
                }
                product.AddProductVariation(variation);
            }
        }

        private void SaveProductImages(ProductForm model, Product product)
        {
            if (model.ThumbnailImage != null)
            {
                var fileName = SaveFile(model.ThumbnailImage);
                product.ThumbnailImage = new Media { FileName = fileName };
            }

            // Currently model binder cannot map the collection of file productImages[0], productImages[1]
            foreach (var file in Request.Form.Files)
            {
                if (file.ContentDisposition.Contains("productImages"))
                {
                    model.ProductImages.Add(file);
                }
            }

            foreach (var file in model.ProductImages)
            {
                var fileName = SaveFile(file);
                var productMedia = new ProductMedia
                {
                    Product = product,
                    Media = new Media { FileName = fileName }
                };
                product.AddMedia(productMedia);
            }
        }

        private string SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            mediaService.SaveMedia(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}