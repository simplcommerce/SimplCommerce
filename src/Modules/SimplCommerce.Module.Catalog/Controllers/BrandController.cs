using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Catalog.Services;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.Module.Catalog.Controllers
{
    public class BrandController : Controller
    {
        private int _pageSize;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IProductPricingService _productPricingService;

        public BrandController(IRepository<Product> productRepository,
            IMediaService mediaService,
            IRepository<Category> categoryRepository,
            IRepository<Brand> brandRepository,
            IProductPricingService productPricingService,
            IConfiguration config)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _productPricingService = productPricingService;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        public IActionResult BrandDetail(long id, SearchOption searchOption)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);

            var model = new ProductsByBrand
            {
                BrandId = id,
                BrandName = brand.Name,
                BrandSeoTitle = brand.SeoTitle,
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query = _productRepository.Query().Where(x => x.BrandId == id && x.IsPublished && x.IsVisibleIndividually);

            model.FilterOption.Price.MaxPrice = query.Select(x => x.Price).DefaultIfEmpty(0).Max();
            model.FilterOption.Price.MinPrice = query.Select(x => x.Price).DefaultIfEmpty(0).Min();

            if (searchOption.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= searchOption.MinPrice.Value);
            }

            if (searchOption.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= searchOption.MaxPrice.Value);
            }

            AppendFilterOptionsToModel(model, query);
            var categories = searchOption.GetCategories();
            if (categories.Any())
            {
                var categoryIds = _categoryRepository.Query().Where(x => categories.Contains(x.SeoTitle)).Select(x => x.Id).ToList();
                query = query.Where(x => x.Categories.Any(c => categoryIds.Contains(c.CategoryId)));
            }

            model.TotalProduct = query.Count();
            var currentPageNum = searchOption.Page <= 0 ? 1 : searchOption.Page;
            var offset = (_pageSize * currentPageNum) - _pageSize;
            while (currentPageNum > 1 && offset >= model.TotalProduct)
            {
                currentPageNum--;
                offset = (_pageSize * currentPageNum) - _pageSize;
            }

            query = query
                .Include(x => x.ThumbnailImage);

            query = AppySort(searchOption, query);

            var products = query
                .Select(x => ProductThumbnail.FromProduct(x))
                .Skip(offset)
                .Take(_pageSize)
                .ToList();

            foreach (var product in products)
            {
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
                product.CalculatedProductPrice = _productPricingService.CalculateProductPrice(product);
            }

            model.Products = products;
            model.CurrentSearchOption.PageSize = _pageSize;
            model.CurrentSearchOption.Page = currentPageNum;

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

        private static void AppendFilterOptionsToModel(ProductsByBrand model, IQueryable<Product> query)
        {
            model.FilterOption.Categories = query
                .SelectMany(x => x.Categories).Where(x => x.Category.Parent == null)
                .GroupBy(x => new {
                    x.Category.Id,
                    x.Category.Name,
                    x.Category.SeoTitle
                })
                .Select(g => new FilterCategory
                {
                    Id = (int)g.Key.Id,
                    Name = g.Key.Name,
                    SeoTitle = g.Key.SeoTitle,
                    Count = g.Count()
                }).ToList();
        }
    }
}
