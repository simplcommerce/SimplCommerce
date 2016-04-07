using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Shopcuatoi.Core.ApplicationServices;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Web.Areas.Admin.ViewModels.Products;
using Shopcuatoi.Web.Areas.Admin.ViewModels.SmartTable;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Shopcuatoi.Web.Extensions;

namespace Shopcuatoi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMediaService mediaService;
        private readonly IUrlSlugService urlSlugService;
        private readonly IRepository<ProductCategory> productCategoryRepository;
        private readonly IRepository<ProductAttributeValue> productAttributeValueRepository; 

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService, IUrlSlugService urlSlugService, IRepository<ProductCategory> productCategoryRepository, IRepository<ProductAttributeValue> productAttributeValueRepository)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
            this.urlSlugService = urlSlugService;
            this.productCategoryRepository = productCategoryRepository;
            this.productAttributeValueRepository = productAttributeValueRepository;
        }

        public IActionResult Get(long id)
        {
            var product = productRepository.Get(id);

            var productVm = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Specification = product.Specification,
                OldPrice = product.OldPrice,
                Price = product.Price,
                CategoryIds = product.Categories.Select(x => x.CategoryId).ToList(),
                ThumbnailImageUrl = mediaService.GetThumbnailUrl(product.ThumbnailImage),
                ManufacturerId = product.ManufacturerId
            };

            foreach (var productMedia in product.Medias)
            {
                productVm.ProductMedias.Add(new ProductMediaVm
                {
                    Id = productMedia.Id,
                    MediaUrl = mediaService.GetThumbnailUrl(productMedia.Media)
                });
            }

            var attributes = from attr in product.AttributeValues
                             group attr by new
                             {
                                 attr.AttributeId,
                                 attr.Attribute.Name,
                                 attr.ProductId
                             }
                             into g
                             select new ProductAttributeVm
                             {
                                 Id = g.Key.AttributeId,
                                 Name = g.Key.Name,
                                 Values = g.Select(x => x.Value).Distinct().ToList()
                             };

            productVm.Attributes = attributes.ToList();

            foreach (var variation in product.Variations.Where(x => !x.IsDeleted))
            {
                productVm.Variations.Add(new ProductVariationVm
                {
                    Id = variation.Id,
                    Name = variation.Name,
                    PriceOffset = variation.PriceOffset,
                    AttributeCombinations = variation.AttributeCombinations.Select(x => new ProductAttributeCombinationVm
                    {
                        AttributeId = x.AttributeId,
                        AttributeName = x.Attribute.Name,
                        Value = x.Value
                    }).ToList()
                });
            }

            return Json(productVm);
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
                IsPublished = model.Product.IsPublished,
                ManufacturerId = model.Product.ManufacturerId
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

        [HttpPost]
        public IActionResult Edit(long id, ProductForm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState.ToDictionary());
            }

            var product = productRepository.Get(id);
            product.Name = model.Product.Name;
            product.ShortDescription = model.Product.ShortDescription;
            product.Description = model.Product.Description;
            product.Specification = model.Product.Specification;
            product.Price = model.Product.Price;
            product.OldPrice = model.Product.OldPrice;
            product.ManufacturerId = model.Product.ManufacturerId;

            SaveProductImages(model, product);

            foreach (var productMediaId in model.Product.DeletedMediaIds)
            {
                var productMedia = product.Medias.First(x => x.Id == productMediaId);
                mediaService.DeleteMedia(productMedia.Media);
                product.RemoveMedia(productMedia);
            }

            AddOrDeleteProductAttribute(model, product);

            AddOrDeleteProductVariation(model, product);

            AddOrDeleteCategories(model, product);

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

        private void AddOrDeleteCategories(ProductForm model, Product product)
        {
            foreach (var categoryId in model.Product.CategoryIds)
            {
                if (product.Categories.Any(x => x.CategoryId == categoryId))
                {
                    continue;
                }

                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };
                product.AddCategory(productCategory);
            }

            var deletedProductCategories =
                product.Categories.Where(productCategory => !model.Product.CategoryIds.Contains(productCategory.CategoryId))
                    .ToList();

            foreach (var deletedProductCategory in deletedProductCategories)
            {
                deletedProductCategory.Product = null;
                product.Categories.Remove(deletedProductCategory);
                productCategoryRepository.Remove(deletedProductCategory);
            }
        }

        private void AddOrDeleteProductAttribute(ProductForm model, Product product)
        {
            foreach (var attributeVm in model.Product.Attributes)
            {
                foreach (var value in attributeVm.Values)
                {
                    if (!product.AttributeValues.Any(x => x.AttributeId == attributeVm.Id && x.Value == value))
                    {
                        product.AddAttributeValue(new ProductAttributeValue
                        {
                            Value = value,
                            AttributeId = attributeVm.Id
                        });
                    }
                }
            }

            var deletedProductAttributeValues = new List<ProductAttributeValue>();
            foreach (var productAttributeValue in product.AttributeValues)
            {
                var isExist = false;
                foreach (var attributeVm in model.Product.Attributes)
                {
                    foreach (var value in attributeVm.Values)
                    {
                        if (productAttributeValue.AttributeId == attributeVm.Id && productAttributeValue.Value == value)
                        {
                            isExist = true;
                            break;;
                        }
                    }
                    if (isExist)
                    {
                        break;
                    }
                }
                if (!isExist)
                {
                    deletedProductAttributeValues.Add(productAttributeValue);
                }
            }

            foreach (var productAttrVale in deletedProductAttributeValues)
            {
                product.AttributeValues.Remove(productAttrVale);
                productAttributeValueRepository.Remove(productAttrVale);
            }
        }

        private void AddOrDeleteProductVariation(ProductForm model, Product product)
        {
            foreach (var productVariationVm in model.Product.Variations)
            {
                var variation = product.Variations.FirstOrDefault(x => x.Name == productVariationVm.Name);
                if (variation == null)
                {
                    variation = new ProductVariation
                    {
                        Name = productVariationVm.Name,
                        PriceOffset = productVariationVm.PriceOffset
                    };
                    foreach (var combinationVm in productVariationVm.AttributeCombinations)
                    {
                        variation.AddAttributeCombination(new ProductAttributeCombination
                        {
                            AttributeId = combinationVm.AttributeId,
                            Value = combinationVm.Value
                        });
                    }

                    product.AddProductVariation(variation);
                }
                else
                {
                    variation.PriceOffset = productVariationVm.PriceOffset;
                    variation.IsDeleted = false;
                }
            }

            foreach (var variation in product.Variations)
            {
                if (model.Product.Variations.All(x => x.Name != variation.Name))
                {
                    variation.IsDeleted = true;
                }
            }
        }

        private void SaveProductImages(ProductForm model, Product product)
        {
            if (model.ThumbnailImage != null)
            {
                var fileName = SaveFile(model.ThumbnailImage);
                if (product.ThumbnailImage != null)
                {
                    product.ThumbnailImage.FileName = fileName;
                }
                else
                {
                    product.ThumbnailImage = new Media { FileName = fileName };
                }
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