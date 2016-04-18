using System.Data.Entity;
using System.Linq;
using Shopcuatoi.Core.ApplicationServices;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Web.ViewModels;
using Shopcuatoi.Web.ViewModels.Catalog;
using Microsoft.AspNet.Mvc;

namespace Shopcuatoi.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IMediaService mediaService;
        private readonly IRepository<Product> productRepository;

        public ProductController(IRepository<Product> productRepository, IMediaService mediaService, IRepository<Category> categoryRepository)
        {
            this.productRepository = productRepository;
            this.mediaService = mediaService;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult ProductsByCategory(string catSeoTitle, SearchOption searchOption)
        {
            var category = categoryRepository.Query().FirstOrDefault(x => x.SeoTitle == catSeoTitle);
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

            var query = productRepository.Query()
                .Where(x => x.Categories.Any(c => c.CategoryId == category.Id) && x.IsPublished);

            model.FilterOption.Price.MaxPrice = query.Select(x => x.Price).DefaultIfEmpty().Max();
            model.FilterOption.Price.MinPrice = query.Select(x => x.Price).DefaultIfEmpty().Min();

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
                query = query.Where(x => brands.Contains(x.Brand.SeoTitle));
            }

            model.TotalProduct = query.Count();

            query = AppySort(searchOption, query);

            var products = query.Include(x => x.Brand)
                .Select(x => new ProductListItem
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
                product.ThumbnailUrl = mediaService.GetThumbnailUrl(product.ThumbnailImage);
            }

            model.Products = products;

            return View(model);
        }

        public IActionResult ProductDetail(string seoTitle)
        {
            var product = productRepository.Query()
                .Include(x => x.Medias)
                .Include(x => x.Variations)
                .Include(x => x.Categories.Select(c => c.Category))
                .Include(x => x.AttributeValues.Select(a => a.Attribute))
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
                Url = mediaService.GetMediaUrl(productMedia.Media),
                ThumbnailUrl = mediaService.GetThumbnailUrl(productMedia.Media)
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

        private static void MapProductVariantToProductVm(Product product, ProductDetail model)
        {
            foreach (var variation in product.Variations.Where(x => !x.IsDeleted))
            {
                var variationVm = new ProductDetailVariation
                {
                    Id = variation.Id,
                    PriceOffset = variation.PriceOffset
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