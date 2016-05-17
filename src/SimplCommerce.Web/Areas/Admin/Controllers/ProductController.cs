using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Products;
using SimplCommerce.Web.Areas.Admin.ViewModels.SmartTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMediaService mediaService;
        private readonly IProductService productService;
        private readonly IRepository<ProductCategory> productCategoryRepository;
        private readonly IRepository<ProductOptionValue> productOptionValueRepository;
        private readonly IRepository<ProductAttributeValue> productAttributeValueRepository; 

        public ProductController(
            IRepository<Product> productRepository,
            IMediaService mediaService,
            IProductService productService,
            IRepository<ProductCategory> productCategoryRepository,
            IRepository<ProductOptionValue> productOptionValueRepository,
            IRepository<ProductAttributeValue> productAttributeValueRepository)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
            this.productService = productService;
            this.productCategoryRepository = productCategoryRepository;
            this.productOptionValueRepository = productOptionValueRepository;
            this.productAttributeValueRepository = productAttributeValueRepository;
        }

        public IActionResult Get(long id)
        {
            var product = productRepository.Query().FirstOrDefault(x => x.Id == id);

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
                BrandId = product.BrandId
            };

            foreach (var productMedia in product.Medias)
            {
                productVm.ProductMedias.Add(new ProductMediaVm
                {
                    Id = productMedia.Id,
                    MediaUrl = mediaService.GetThumbnailUrl(productMedia.Media)
                });
            }

            var options = from opt in product.OptionValues
                             group opt by new
                             {
                                 opt.OptionId,
                                 opt.Option.Name,
                                 opt.ProductId
                             }
                             into g
                             select new ProductOptionVm
                             {
                                 Id = g.Key.OptionId,
                                 Name = g.Key.Name,
                                 Values = g.Select(x => x.Value).Distinct().ToList()
                             };

            productVm.Options = options.ToList();

            foreach (var variation in product.Variations.Where(x => !x.IsDeleted))
            {
                productVm.Variations.Add(new ProductVariationVm
                {
                    Id = variation.Id,
                    Name = variation.Name,
                    PriceOffset = variation.PriceOffset,
                    OptionCombinations = variation.OptionCombinations.Select(x => new ProductOptionCombinationVm
                    {
                        OptionId = x.OptionId,
                        OptionName = x.Option.Name,
                        Value = x.Value
                    }).ToList()
                });
            }

            productVm.Attributes = product.AttributeValues.Select(x => new ProductAttributeVm
            {
                AttributeValueId = x.Id,
                Id = x.AttributeId,
                Name = x.Attribute.Name,
                GroupName = x.Attribute.Group.Name,
                Value = x.Value,
                
            }).ToList();

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
                return new BadRequestObjectResult(ModelState);
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
                BrandId = model.Product.BrandId
            };

            foreach (var option in model.Product.Options)
            {
                foreach (var value in option.Values)
                {
                    product.AddOptionValue(new ProductOptionValue
                    {
                        Value = value,
                        OptionId = option.Id
                    });
                }
            }

            MapProductVariationVmToProduct(model, product);

            foreach (var attribute in model.Product.Attributes)
            {
                var attributeValue = new ProductAttributeValue
                {
                    AttributeId = attribute.Id,
                    Value = attribute.Value
                };

                product.AddAttributeValue(attributeValue);
            }

            foreach (var categoryId in model.Product.CategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };
                product.AddCategory(productCategory);
            }

            SaveProductImages(model, product);

            productService.Create(product);

            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(long id, ProductForm model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var product = productRepository.Query().FirstOrDefault(x => x.Id == id);
            product.Name = model.Product.Name;
            product.ShortDescription = model.Product.ShortDescription;
            product.Description = model.Product.Description;
            product.Specification = model.Product.Specification;
            product.Price = model.Product.Price;
            product.OldPrice = model.Product.OldPrice;
            product.BrandId = model.Product.BrandId;

            SaveProductImages(model, product);

            foreach (var productMediaId in model.Product.DeletedMediaIds)
            {
                var productMedia = product.Medias.First(x => x.Id == productMediaId);
                mediaService.DeleteMedia(productMedia.Media);
                product.RemoveMedia(productMedia);
            }

            AddOrDeleteProductOption(model, product);

            AddOrDeleteProductVariation(model, product);

            AddOrDeleteProductAttribute(model, product);

            AddOrDeleteCategories(model, product);

            productService.Update(product);

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
                foreach (var combinationVm in variationVm.OptionCombinations)
                {
                    variation.AddOptionCombination(new ProductOptionCombination
                    {
                        OptionId = combinationVm.OptionId,
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

        private void AddOrDeleteProductOption(ProductForm model, Product product)
        {
            foreach (var optionVm in model.Product.Options)
            {
                foreach (var value in optionVm.Values)
                {
                    if (!product.OptionValues.Any(x => x.OptionId == optionVm.Id && x.Value == value))
                    {
                        product.AddOptionValue(new ProductOptionValue
                        {
                            Value = value,
                            OptionId = optionVm.Id
                        });
                    }
                }
            }

            var deletedProductOptionValues = new List<ProductOptionValue>();
            foreach (var productOptionValue in product.OptionValues)
            {
                var isExist = false;
                foreach (var optionVm in model.Product.Options)
                {
                    foreach (var value in optionVm.Values)
                    {
                        if (productOptionValue.OptionId == optionVm.Id && productOptionValue.Value == value)
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
                    deletedProductOptionValues.Add(productOptionValue);
                }
            }

            foreach (var productOptionValue in deletedProductOptionValues)
            {
                product.OptionValues.Remove(productOptionValue);
                productOptionValueRepository.Remove(productOptionValue);
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
                    foreach (var combinationVm in productVariationVm.OptionCombinations)
                    {
                        variation.AddOptionCombination(new ProductOptionCombination
                        {
                            OptionId = combinationVm.OptionId,
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

        private void AddOrDeleteProductAttribute(ProductForm model, Product product)
        {
            foreach (var productAttributeVm in model.Product.Attributes)
            {
                var productAttrValue =
                    product.AttributeValues.FirstOrDefault(x => x.AttributeId == productAttributeVm.Id);
                if (productAttrValue == null)
                {
                    productAttrValue = new ProductAttributeValue
                    {
                        AttributeId = productAttributeVm.Id,
                        Value = productAttributeVm.Value
                    };
                    product.AddAttributeValue(productAttrValue);
                }
                else
                {
                    productAttrValue.Value = productAttributeVm.Value;
                }
            }

            var deletedAttrValues =
               product.AttributeValues.Where(attrValue => model.Product.Attributes.All(x => x.Id != attrValue.AttributeId))
                   .ToList();

            foreach (var deletedAttrValue in deletedAttrValues)
            {
                deletedAttrValue.Product = null;
                product.AttributeValues.Remove(deletedAttrValue);
                productAttributeValueRepository.Remove(deletedAttrValue);
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