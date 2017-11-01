using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Search.ViewModels;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Search.Models;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Module.Catalog.Services;

namespace SimplCommerce.Module.Search.Controllers
{
    public class SearchController : Controller
    {
        private int _pageSize;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Query> _queryRepository;
        private readonly IProductPricingService _productPricingService;

        public SearchController(IRepository<Product> productRepository,
            IRepository<Brand> brandRepository,
            IRepository<Category> categoryRepository,
            IMediaService mediaService,
            IRepository<Query> queryRepository,
            IProductPricingService productPricingService,
            IConfiguration config)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _mediaService = mediaService;
            _queryRepository = queryRepository;
            _productPricingService = productPricingService;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        [HttpGet("search")]
        public IActionResult Index(SearchOption searchOption)
        {
            if (string.IsNullOrWhiteSpace(searchOption.Query))
            {
                return Redirect("~/");
            }

            var brand = _brandRepository.Query().FirstOrDefault(x => x.Name == searchOption.Query && x.IsPublished);
            if(brand != null)
            {
                return Redirect(string.Format("~/{0}", brand.SeoTitle));
            }

            var model = new SearchResult
            {
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query = _productRepository.Query().Where(x => x.Name.Contains(searchOption.Query) && x.IsPublished && x.IsVisibleIndividually);

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
            if (string.Compare(model.CurrentSearchOption.Category, "all", StringComparison.OrdinalIgnoreCase) != 0)
            {
                var categories = searchOption.GetCategories();
                if (categories.Any())
                {
                    var categoryIds = _categoryRepository.Query().Where(x => categories.Contains(x.SeoTitle)).Select(x => x.Id).ToList();
                    query = query.Where(x => x.Categories.Any(c => categoryIds.Contains(c.CategoryId)));
                }
            }

            var brands = searchOption.GetBrands();
            if (brands.Any())
            {
                var brandIs = _brandRepository.Query().Where(x => brands.Contains(x.SeoTitle)).Select(x => x.Id).ToList();
                query = query.Where(x => x.BrandId.HasValue && brandIs.Contains(x.BrandId.Value));
            }

            model.TotalProduct = query.Count();
            var currentPageNum = searchOption.Page <= 0 ? 1 : searchOption.Page;
            var offset = (_pageSize * currentPageNum) - _pageSize;
            while (currentPageNum > 1 && offset >= model.TotalProduct)
            {
                currentPageNum--;
                offset = (_pageSize * currentPageNum) - _pageSize;
            }

            SaveSearchQuery(searchOption, model);

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

        private static void AppendFilterOptionsToModel(SearchResult model, IQueryable<Product> query)
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

        private void SaveSearchQuery(SearchOption searchOption, SearchResult model)
        {
            var query = new Query
            {
                CreatedOn = DateTimeOffset.Now,
                QueryText = searchOption.Query,
                ResultsCount = model.TotalProduct
            };

            _queryRepository.Add(query);
            _queryRepository.SaveChanges();
        }
    }
}
