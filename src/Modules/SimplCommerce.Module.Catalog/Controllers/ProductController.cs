using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Catalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<Brand> _brandRepository;

        public ProductController(IRepository<Product> productRepository,
            IMediaService mediaService,
            IRepository<Category> categoryRepository,
            IRepository<ProductCategory> productCategoryRepository,
            IRepository<Brand> brandRepository)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _brandRepository = brandRepository;
        }

        public IActionResult ProductsByCategory(string catSeoTitle, SearchOption searchOption)
        {
            var category = _categoryRepository.Query().FirstOrDefault(x => x.SeoTitle == catSeoTitle);
            if (category == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new ProductsByCategory
            {
                CategoryId = category.Id,
                ParentCategorId = category.ParentId,
                CategoryName = category.Name,
                CategorySeoTitle = category.SeoTitle,
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query = _productCategoryRepository
                .Query()
                .Where(x => x.CategoryId == category.Id && x.Product.IsPublished && x.Product.IsVisibleIndividually)
                .Select(x => x.Product);

            model.FilterOption.Price.MaxPrice = query.Max(x => x.Price);
            model.FilterOption.Price.MinPrice = query.Min(x => x.Price);

            if (searchOption.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= searchOption.MinPrice.Value);
            }

            if (searchOption.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= searchOption.MaxPrice.Value);
            }

            AppendFilterOptionsToModel(model, query);

            var brands = searchOption.GetBrands();
            if (brands.Any())
            {
                var brandIs = _brandRepository.Query().Where(x => brands.Contains(x.SeoTitle)).Select(x => x.Id).ToList();
                query = query.Where(x => x.BrandId.HasValue && brandIs.Contains(x.BrandId.Value));
            }

            model.TotalProduct = query.Count();

            query = query
                .Include(x => x.Brand)
                .Include(x => x.ThumbnailImage)
                .Include(x => x.ProductLinks);

            query = AppySort(searchOption, query);

            var products = query
                .Select(x => new ProductThumbnail
                {
                    Id = x.Id,
                    Name = x.Name,
                    SeoTitle = x.SeoTitle,
                    Price = x.Price,
                    OldPrice = x.OldPrice,
                    ThumbnailImage = x.ThumbnailImage
                }).ToList();

            foreach (var product in products)
            {
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
            }

            model.Products = products;

            return View(model);
        }

        public IActionResult ProductDetail(string seoTitle)
        {
            var product = _productRepository.Query()
                .Include(x => x.Medias)
                .Include(x => x.Categories).ThenInclude(c => c.Category)
                .Include(x => x.AttributeValues).ThenInclude(a => a.Attribute)
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .FirstOrDefault(x => x.SeoTitle == seoTitle && x.IsPublished);
            if (product == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new ProductDetail
            {
                Id = product.Id,
                Name = product.Name,
                OldPrice = product.OldPrice,
                Price = product.Price,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Specification = product.Specification,
                Attributes = product.AttributeValues.Select(x => new ProductDetailAttribute { Name = x.Attribute.Name, Value = x.Value }).ToList(),
                Categories = product.Categories.Select(x => new ProductDetailCategory { Id = x.CategoryId, Name = x.Category.Name, SeoTitle = x.Category.SeoTitle }).ToList()
            };

            MapProductVariantToProductVm(product, model);

            foreach (var mediaViewModel in product.Medias.Select(productMedia => new MediaViewModel
            {
                Url = _mediaService.GetMediaUrl(productMedia.Media),
                ThumbnailUrl = _mediaService.GetThumbnailUrl(productMedia.Media)
            }))
            {
                model.Images.Add(mediaViewModel);
            }

            return View(model);
        }

        private static IQueryable<Product> AppySort(SearchOption searchOption, IQueryable<Product> query)
        {
            var sortBy = searchOption.Sort ?? string.Empty;
            switch (sortBy.ToLower())
            {
                case "price-desc":
                    query = query.OrderByDescending(x => x.Price);
                    break;
                default:
                    query = query.OrderBy(x => x.Price);
                    break;
            }

            return query;
        }

        private static void AppendFilterOptionsToModel(ProductsByCategory model, IQueryable<Product> query)
        {
            model.FilterOption.Brands = query
                .Where(x => x.BrandId != null)
                .GroupBy(x => x.Brand)
                .Select(g => new FilterBrand
                {
                    Id = (int)g.Key.Id,
                    Name = g.Key.Name,
                    SeoTitle = g.Key.SeoTitle,
                    Count = g.Count()
                }).ToList();
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
                    Price = variation.Price
                };

                foreach (var combination in variation.OptionCombinations)
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
    }
}
