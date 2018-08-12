using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Catalog.Controllers
{
    [Authorize(Roles = "admin, vendor")]
    [Route("api/products")]
    public class ProductApiController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<ProductAttributeValue> _productAttributeValueRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<ProductLink> _productLinkRepository;
        private readonly IRepository<ProductOptionValue> _productOptionValueRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IProductService _productService;
        private readonly IRepository<ProductMedia> _productMediaRepository;
        private readonly IWorkContext _workContext;

        public ProductApiController(
            IRepository<Product> productRepository,
            IMediaService mediaService,
            IProductService productService,
            IRepository<ProductLink> productLinkRepository,
            IRepository<ProductCategory> productCategoryRepository,
            IRepository<ProductOptionValue> productOptionValueRepository,
            IRepository<ProductAttributeValue> productAttributeValueRepository,
            IRepository<ProductMedia> productMediaRepository,
            IWorkContext workContext)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _productService = productService;
            _productLinkRepository = productLinkRepository;
            _productCategoryRepository = productCategoryRepository;
            _productOptionValueRepository = productOptionValueRepository;
            _productAttributeValueRepository = productAttributeValueRepository;
            _productMediaRepository = productMediaRepository;
            _workContext = workContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var product = _productRepository.Query()
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .Include(x => x.ProductLinks).ThenInclude(p => p.LinkedProduct)
                .Include(x => x.OptionValues).ThenInclude(o => o.Option)
                .Include(x => x.AttributeValues).ThenInclude(a => a.Attribute).ThenInclude(g => g.Group)
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == id);

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin") && product.VendorId != currentUser.VendorId)
            {
                return new BadRequestObjectResult(new { error = "You don't have permission to manage this product" });
            }

            var productVm = new ProductVm
            {
                Id = product.Id,
                Name = product.Name,
                Slug = product.Slug,
                MetaTitle = product.MetaTitle,
                MetaKeywords = product.MetaKeywords,
                MetaDescription = product.MetaDescription,
                Sku = product.Sku,
                Gtin = product.Gtin,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Specification = product.Specification,
                OldPrice = product.OldPrice,
                Price = product.Price,
                SpecialPrice = product.SpecialPrice,
                SpecialPriceStart = product.SpecialPriceStart,
                SpecialPriceEnd = product.SpecialPriceEnd,
                IsFeatured = product.IsFeatured,
                IsPublished = product.IsPublished,
                IsCallForPricing =  product.IsCallForPricing,
                IsAllowToOrder = product.IsAllowToOrder,
                CategoryIds = product.Categories.Select(x => x.CategoryId).ToList(),
                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage),
                BrandId = product.BrandId,
                TaxClassId = product.TaxClassId,
                StockTrackingIsEnabled = product.StockTrackingIsEnabled
            };

            foreach (var productMedia in product.Medias.Where(x => x.Media.MediaType == MediaType.Image))
            {
                productVm.ProductImages.Add(new ProductMediaVm
                {
                    Id = productMedia.Id,
                    MediaUrl = _mediaService.GetThumbnailUrl(productMedia.Media)
                });
            }

            foreach (var productMedia in product.Medias.Where(x => x.Media.MediaType == MediaType.File))
            {
                productVm.ProductDocuments.Add(new ProductMediaVm
                {
                    Id = productMedia.Id,
                    Caption = productMedia.Media.Caption,
                    MediaUrl = _mediaService.GetMediaUrl(productMedia.Media)
                });
            }


            productVm.Options = product.OptionValues.OrderBy(x => x.SortIndex).Select(x =>
                new ProductOptionVm
                {
                    Id = x.OptionId,
                    Name = x.Option.Name,
                    DisplayType = x.DisplayType,
                    Values = JsonConvert.DeserializeObject<IList<ProductOptionValueVm>>(x.Value)
                }).ToList();

            foreach (var variation in product.ProductLinks.Where(x => x.LinkType == ProductLinkType.Super).Select(x => x.LinkedProduct).Where(x => !x.IsDeleted).OrderBy(x => x.Id))
            {
                productVm.Variations.Add(new ProductVariationVm
                {
                    Id = variation.Id,
                    Name = variation.Name,
                    Sku = variation.Sku,
                    Gtin = variation.Gtin,
                    Price = variation.Price,
                    OldPrice = variation.OldPrice,
                    NormalizedName = variation.NormalizedName,
                    OptionCombinations = variation.OptionCombinations.Select(x => new ProductOptionCombinationVm
                    {
                        OptionId = x.OptionId,
                        OptionName = x.Option.Name,
                        Value = x.Value,
                        SortIndex = x.SortIndex
                    }).OrderBy(x => x.SortIndex).ToList()
                });
            }

            foreach (var relatedProduct in product.ProductLinks.Where(x => x.LinkType == ProductLinkType.Related).Select(x => x.LinkedProduct).Where(x => !x.IsDeleted).OrderBy(x => x.Id))
            {
                productVm.RelatedProducts.Add(new ProductLinkVm
                {
                    Id = relatedProduct.Id,
                    Name = relatedProduct.Name,
                    IsPublished = relatedProduct.IsPublished
                });
            }

            foreach (var crossSellProduct in product.ProductLinks.Where(x => x.LinkType == ProductLinkType.CrossSell).Select(x => x.LinkedProduct).Where(x => !x.IsDeleted).OrderBy(x => x.Id))
            {
                productVm.CrossSellProducts.Add(new ProductLinkVm
                {
                    Id = crossSellProduct.Id,
                    Name = crossSellProduct.Name,
                    IsPublished = crossSellProduct.IsPublished
                });
            }

            productVm.Attributes = product.AttributeValues.Select(x => new ProductAttributeVm
            {
                AttributeValueId = x.Id,
                Id = x.AttributeId,
                Name = x.Attribute.Name,
                GroupName = x.Attribute.Group.Name,
                Value = x.Value
            }).ToList();

            return Json(productVm);
        }

        [HttpPost("grid")]
        public async Task<IActionResult> List([FromBody] SmartTableParam param)
        {
            var query = _productRepository.Query().Where(x => !x.IsDeleted);
            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                query = query.Where(x => x.VendorId == currentUser.VendorId);
            }

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.Name != null)
                {
                    string name = search.Name;
                    query = query.Where(x => x.Name.Contains(name));
                }

                if (search.HasOptions != null)
                {
                    bool hasOptions = search.HasOptions;
                    query = query.Where(x => x.HasOptions == hasOptions);
                }

                if (search.IsVisibleIndividually != null)
                {
                    bool isVisibleIndividually = search.IsVisibleIndividually;
                    query = query.Where(x => x.IsVisibleIndividually == isVisibleIndividually);
                }

                if (search.IsPublished != null)
                {
                    bool isPublished = search.IsPublished;
                    query = query.Where(x => x.IsPublished == isPublished);
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        query = query.Where(x => x.CreatedOn >= after);
                    }
                }
            }

            var gridData = query.ToSmartTableResult(
                param,
                x => new ProductListItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    HasOptions = x.HasOptions,
                    IsVisibleIndividually = x.IsVisibleIndividually,
                    IsFeatured = x.IsFeatured,
                    IsAllowToOrder = x.IsAllowToOrder,
                    IsCallForPricing = x.IsCallForPricing,
                    StockQuantity = x.StockQuantity,
                    CreatedOn = x.CreatedOn,
                    IsPublished = x.IsPublished
                });

            return Json(gridData);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _workContext.GetCurrentUser();

            var product = new Product
            {
                Name = model.Product.Name,
                Slug = model.Product.Slug,
                MetaTitle = model.Product.MetaTitle,
                MetaKeywords = model.Product.MetaKeywords,
                MetaDescription = model.Product.MetaDescription,
                Sku = model.Product.Sku,
                Gtin = model.Product.Gtin,
                ShortDescription = model.Product.ShortDescription,
                Description = model.Product.Description,
                Specification = model.Product.Specification,
                Price = model.Product.Price,
                OldPrice = model.Product.OldPrice,
                SpecialPrice = model.Product.SpecialPrice,
                SpecialPriceStart = model.Product.SpecialPriceStart,
                SpecialPriceEnd = model.Product.SpecialPriceEnd,
                IsPublished = model.Product.IsPublished,
                IsFeatured = model.Product.IsFeatured,
                IsCallForPricing = model.Product.IsCallForPricing,
                IsAllowToOrder = model.Product.IsAllowToOrder,
                BrandId = model.Product.BrandId,
                TaxClassId = model.Product.TaxClassId,
                StockTrackingIsEnabled = model.Product.StockTrackingIsEnabled,
                HasOptions = model.Product.Variations.Any() ? true : false,
                IsVisibleIndividually = true,
                CreatedBy = currentUser
            };

            if (!User.IsInRole("admin"))
            {
                product.VendorId = currentUser.VendorId;
            }

            var optionIndex = 0;
            foreach (var option in model.Product.Options)
            {
                product.AddOptionValue(new ProductOptionValue
                {
                    OptionId = option.Id,
                    DisplayType = option.DisplayType,
                    Value = JsonConvert.SerializeObject(option.Values),
                    SortIndex = optionIndex
                });

                optionIndex++;
            }

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

            await SaveProductMedias(model, product);

            MapProductVariationVmToProduct(currentUser, model, product);
            MapProductLinkVmToProduct(model, product);

            var productPriceHistory = CreatePriceHistory(currentUser, product);
            product.PriceHistories.Add(productPriceHistory);

            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, ProductForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _productRepository.Query()
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .Include(x => x.ProductLinks).ThenInclude(x => x.LinkedProduct)
                .Include(x => x.OptionValues).ThenInclude(o => o.Option)
                .Include(x => x.AttributeValues).ThenInclude(a => a.Attribute).ThenInclude(g => g.Group)
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin") && product.VendorId != currentUser.VendorId)
            {
                return BadRequest(new { error = "You don't have permission to manage this product" });
            }

            var isPriceChanged = false;
            if (product.Price != model.Product.Price ||
                product.OldPrice != model.Product.OldPrice ||
                product.SpecialPrice != model.Product.SpecialPrice ||
                product.SpecialPriceStart != model.Product.SpecialPriceStart ||
                product.SpecialPriceEnd != model.Product.SpecialPriceEnd)
            {
                isPriceChanged = true;
            }


            product.Name = model.Product.Name;
            product.Slug = model.Product.Slug;
            product.MetaTitle = model.Product.MetaTitle;
            product.MetaKeywords = model.Product.MetaKeywords;
            product.MetaDescription = model.Product.MetaDescription;
            product.Sku = model.Product.Sku;
            product.Gtin = model.Product.Gtin;
            product.ShortDescription = model.Product.ShortDescription;
            product.Description = model.Product.Description;
            product.Specification = model.Product.Specification;
            product.Price = model.Product.Price;
            product.OldPrice = model.Product.OldPrice;
            product.SpecialPrice = model.Product.SpecialPrice;
            product.SpecialPriceStart = model.Product.SpecialPriceStart;
            product.SpecialPriceEnd = model.Product.SpecialPriceEnd;
            product.BrandId = model.Product.BrandId;
            product.TaxClassId = model.Product.TaxClassId;
            product.IsFeatured = model.Product.IsFeatured;
            product.IsPublished = model.Product.IsPublished;
            product.IsCallForPricing = model.Product.IsCallForPricing;
            product.IsAllowToOrder = model.Product.IsAllowToOrder;
            product.StockTrackingIsEnabled = model.Product.StockTrackingIsEnabled;
            product.UpdatedBy = currentUser;

            if (isPriceChanged)
            {
                var productPriceHistory = CreatePriceHistory(currentUser, product);
                product.PriceHistories.Add(productPriceHistory);
            }

            await SaveProductMedias(model, product);

            foreach (var productMediaId in model.Product.DeletedMediaIds)
            {
                var productMedia = product.Medias.First(x => x.Id == productMediaId);
                _productMediaRepository.Remove(productMedia);
                await _mediaService.DeleteMediaAsync(productMedia.Media);
            }

            AddOrDeleteProductOption(model, product);
            AddOrDeleteProductAttribute(model, product);
            AddOrDeleteCategories(model, product);
            AddOrDeleteProductVariation(currentUser, model, product);
            AddOrDeleteProductLinks(model, product);

            _productService.Update(product);

            return Accepted();
        }

        [HttpPost("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(long id)
        {
            var product = _productRepository.Query().FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin") && product.VendorId != currentUser.VendorId)
            {
                return BadRequest(new { error = "You don't have permission to manage this product" });
            }

            product.IsPublished = !product.IsPublished;
            await _productRepository.SaveChangesAsync();

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var product = _productRepository.Query().FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin") && product.VendorId != currentUser.VendorId)
            {
                return new BadRequestObjectResult(new { error = "You don't have permission to manage this product" });
            }

            await _productService.Delete(product);

            return NoContent();
        }

        private static void MapProductVariationVmToProduct(User loginUser, ProductForm model, Product product)
        {
            foreach (var variationVm in model.Product.Variations)
            {
                var productLink = new ProductLink
                {
                    LinkType = ProductLinkType.Super,
                    Product = product,
                    LinkedProduct = product.Clone()
                };

                productLink.LinkedProduct.Name = variationVm.Name;
                productLink.LinkedProduct.Slug = variationVm.Name.ToUrlFriendly();
                productLink.LinkedProduct.Sku = variationVm.Sku;
                productLink.LinkedProduct.Gtin = variationVm.Gtin;
                productLink.LinkedProduct.Price = variationVm.Price;
                productLink.LinkedProduct.OldPrice = variationVm.OldPrice;
                productLink.LinkedProduct.NormalizedName = variationVm.NormalizedName;
                productLink.LinkedProduct.HasOptions = false;
                productLink.LinkedProduct.IsVisibleIndividually = false;

                foreach (var combinationVm in variationVm.OptionCombinations)
                {
                    productLink.LinkedProduct.AddOptionCombination(new ProductOptionCombination
                    {
                        OptionId = combinationVm.OptionId,
                        Value = combinationVm.Value,
                        SortIndex = combinationVm.SortIndex
                    });
                }

                productLink.LinkedProduct.ThumbnailImage = product.ThumbnailImage;

                var productPriceHistory = CreatePriceHistory(loginUser, productLink.LinkedProduct);
                product.PriceHistories.Add(productPriceHistory);

                product.AddProductLinks(productLink);
            }
        }

        private static ProductPriceHistory CreatePriceHistory(User loginUser, Product product)
        {
            return new ProductPriceHistory
            {
                CreatedBy = loginUser,
                Product = product,
                Price = product.Price,
                OldPrice = product.OldPrice,
                SpecialPrice = product.SpecialPrice,
                SpecialPriceStart = product.SpecialPriceStart,
                SpecialPriceEnd = product.SpecialPriceEnd
            };
        }

        private static void MapProductLinkVmToProduct(ProductForm model, Product product)
        {
            foreach (var relatedProductVm in model.Product.RelatedProducts)
            {
                var productLink = new ProductLink
                {
                    LinkType = ProductLinkType.Related,
                    Product = product,
                    LinkedProductId = relatedProductVm.Id
                };

                product.AddProductLinks(productLink);
            }

            foreach (var crossSellProductVm in model.Product.CrossSellProducts)
            {
                var productLink = new ProductLink
                {
                    LinkType = ProductLinkType.CrossSell,
                    Product = product,
                    LinkedProductId = crossSellProductVm.Id
                };

                product.AddProductLinks(productLink);
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
                _productCategoryRepository.Remove(deletedProductCategory);
            }
        }

        private void AddOrDeleteProductOption(ProductForm model, Product product)
        {
            var optionIndex = 0;
            foreach (var optionVm in model.Product.Options)
            {
                var optionValue = product.OptionValues.FirstOrDefault(x => x.OptionId == optionVm.Id);
                if (optionValue == null)
                {
                    product.AddOptionValue(new ProductOptionValue
                    {
                        OptionId = optionVm.Id,
                        DisplayType = optionVm.DisplayType,
                        Value = JsonConvert.SerializeObject(optionVm.Values),
                        SortIndex = optionIndex
                    });
                }
                else
                {
                    optionValue.Value = JsonConvert.SerializeObject(optionVm.Values);
                    optionValue.DisplayType = optionVm.DisplayType;
                    optionValue.SortIndex = optionIndex;
                }

                optionIndex++;
            }

            var deletedProductOptionValues = product.OptionValues.Where(x => model.Product.Options.All(vm => vm.Id != x.OptionId)).ToList();

            foreach (var productOptionValue in deletedProductOptionValues)
            {
                product.OptionValues.Remove(productOptionValue);
                _productOptionValueRepository.Remove(productOptionValue);
            }
        }

        private void AddOrDeleteProductVariation(User loginUser,  ProductForm model, Product product)
        {
            foreach (var productVariationVm in model.Product.Variations)
            {
                var productLink = product.ProductLinks.Where(x => x.LinkType == ProductLinkType.Super).FirstOrDefault(x => x.LinkedProduct.Name == productVariationVm.Name);
                if (productLink == null)
                {
                    productLink = new ProductLink
                    {
                        LinkType = ProductLinkType.Super,
                        Product = product,
                        LinkedProduct = product.Clone()
                    };

                    productLink.LinkedProduct.Name = productVariationVm.Name;
                    productLink.LinkedProduct.Slug = StringHelper.ToUrlFriendly(productVariationVm.Name);
                    productLink.LinkedProduct.Sku = productVariationVm.Sku;
                    productLink.LinkedProduct.Gtin = productVariationVm.Gtin;
                    productLink.LinkedProduct.Price = productVariationVm.Price;
                    productLink.LinkedProduct.OldPrice = productVariationVm.OldPrice;
                    productLink.LinkedProduct.NormalizedName = productVariationVm.NormalizedName;
                    productLink.LinkedProduct.HasOptions = false;
                    productLink.LinkedProduct.IsVisibleIndividually = false;
                    productLink.LinkedProduct.ThumbnailImage = product.ThumbnailImage;

                    foreach (var combinationVm in productVariationVm.OptionCombinations)
                    {
                        productLink.LinkedProduct.AddOptionCombination(new ProductOptionCombination
                        {
                            OptionId = combinationVm.OptionId,
                            Value = combinationVm.Value,
                            SortIndex = combinationVm.SortIndex
                        });
                    }

                    var productPriceHistory = CreatePriceHistory(loginUser, productLink.LinkedProduct);
                    productLink.LinkedProduct.PriceHistories.Add(productPriceHistory);

                    product.AddProductLinks(productLink);
                }
                else
                {
                    var isPriceChanged = false;
                    if(productLink.LinkedProduct.Price != productVariationVm.Price ||
                        productLink.LinkedProduct.OldPrice != productVariationVm.OldPrice)
                    {
                        isPriceChanged = true;
                    }

                    productLink.LinkedProduct.Sku = productVariationVm.Sku;
                    productLink.LinkedProduct.Gtin = productVariationVm.Gtin;
                    productLink.LinkedProduct.Price = productVariationVm.Price;
                    productLink.LinkedProduct.OldPrice = productVariationVm.OldPrice;
                    productLink.LinkedProduct.IsDeleted = false;
                    productLink.LinkedProduct.StockTrackingIsEnabled = product.StockTrackingIsEnabled;

                    if (isPriceChanged)
                    {
                        var productPriceHistory = CreatePriceHistory(loginUser, productLink.LinkedProduct);
                        productLink.LinkedProduct.PriceHistories.Add(productPriceHistory);
                    }
                }
            }

            foreach (var productLink in product.ProductLinks.Where(x => x.LinkType == ProductLinkType.Super))
            {
                if (model.Product.Variations.All(x => x.Name != productLink.LinkedProduct.Name))
                {
                    _productLinkRepository.Remove(productLink);
                    productLink.LinkedProduct.IsDeleted = true;
                }
            }
        }

        // Due to some issue with EF Core, we have to use _productLinkRepository in this case.
        private void AddOrDeleteProductLinks(ProductForm model, Product product)
        {
            foreach (var relatedProductVm in model.Product.RelatedProducts)
            {
                var productLink = product.ProductLinks.Where(x => x.LinkType == ProductLinkType.Related).FirstOrDefault(x => x.LinkedProductId == relatedProductVm.Id);
                if (productLink == null)
                {
                    productLink = new ProductLink
                    {
                        LinkType = ProductLinkType.Related,
                        Product = product,
                        LinkedProductId = relatedProductVm.Id,
                    };

                    _productLinkRepository.Add(productLink);
                }
            }

            foreach (var productLink in product.ProductLinks.Where(x => x.LinkType == ProductLinkType.Related))
            {
                if (model.Product.RelatedProducts.All(x => x.Id != productLink.LinkedProductId))
                {
                    _productLinkRepository.Remove(productLink);
                }
            }

            foreach (var crossSellProductVm in model.Product.CrossSellProducts)
            {
                var productLink = product.ProductLinks.Where(x => x.LinkType == ProductLinkType.CrossSell).FirstOrDefault(x => x.LinkedProductId == crossSellProductVm.Id);
                if (productLink == null)
                {
                    productLink = new ProductLink
                    {
                        LinkType = ProductLinkType.CrossSell,
                        Product = product,
                        LinkedProductId = crossSellProductVm.Id,
                    };

                    _productLinkRepository.Add(productLink);
                }
            }

            foreach (var productLink in product.ProductLinks.Where(x => x.LinkType == ProductLinkType.CrossSell))
            {
                if (model.Product.CrossSellProducts.All(x => x.Id != productLink.LinkedProductId))
                {
                    _productLinkRepository.Remove(productLink);
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
                _productAttributeValueRepository.Remove(deletedAttrValue);
            }
        }

        private async Task SaveProductMedias(ProductForm model, Product product)
        {
            if (model.ThumbnailImage != null)
            {
                var fileName = await SaveFile(model.ThumbnailImage);
                if (product.ThumbnailImage != null)
                {
                    product.ThumbnailImage.FileName = fileName;
                }
                else
                {
                    product.ThumbnailImage = new Media {FileName = fileName};
                }
            }

            // Currently model binder cannot map the collection of file productImages[0], productImages[1]
            foreach (var file in Request.Form.Files)
            {
                if (file.ContentDisposition.Contains("productImages"))
                {
                    model.ProductImages.Add(file);
                }
                else if (file.ContentDisposition.Contains("productDocuments"))
                {
                    model.ProductDocuments.Add(file);
                }
            }

            foreach (var file in model.ProductImages)
            {
                var fileName = await SaveFile(file);
                var productMedia = new ProductMedia
                {
                    Product = product,
                    Media = new Media {FileName = fileName, MediaType = MediaType.Image}
                };
                product.AddMedia(productMedia);
            }

            foreach (var file in model.ProductDocuments)
            {
                var fileName = await SaveFile(file);
                var productMedia = new ProductMedia
                {
                    Product = product,
                    Media = new Media { FileName = fileName, MediaType = MediaType.File, Caption = file.FileName }
                };
                product.AddMedia(productMedia);
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}