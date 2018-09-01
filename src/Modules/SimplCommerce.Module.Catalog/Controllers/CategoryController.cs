using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Services;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.Module.Catalog.Controllers
{
    public class CategoryController : Controller
    {
        private int _pageSize;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IProductPricingService _productPricingService;

        public CategoryController(IRepository<Product> productRepository,
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

        public IActionResult CategoryDetail(long id, SearchOption searchOption)
        {
            var category = _categoryRepository.Query().FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new ProductsByCategory
            {
                CategoryId = category.Id,
                ParentCategorId = category.ParentId,
                CategoryName = category.Name,
                CategorySlug = category.Slug,
                CategoryMetaTitle = category.MetaTitle,
                CategoryMetaKeywords = category.MetaKeywords,
                CategoryMetaDescription = category.MetaDescription,
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query = _productRepository
                .Query()
                .Where(x => x.Categories.Any(c => c.CategoryId == category.Id) && x.IsPublished && x.IsVisibleIndividually);

            if (query.Count() == 0)
            {
                model.TotalProduct = 0;
                return View(model);
            }

            AppendFilterOptionsToModel(model, query);

            if (searchOption.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= searchOption.MinPrice.Value);
            }

            if (searchOption.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= searchOption.MaxPrice.Value);
            }

            var brands = searchOption.GetBrands();
            if (brands.Any())
            {
                var brandIds = _brandRepository.Query().Where(x => brands.Contains(x.Slug)).Select(x => x.Id).ToList();
                query = query.Where(x => x.BrandId.HasValue && brandIds.Contains(x.BrandId.Value));
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
                .Include(x => x.Brand)
                .Include(x => x.ThumbnailImage);

            query = ApplySort(searchOption, query);

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

        private static IQueryable<Product> ApplySort(SearchOption searchOption, IQueryable<Product> query)
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
            model.FilterOption.Price.MaxPrice = query.Max(x => x.Price);
            model.FilterOption.Price.MinPrice = query.Min(x => x.Price);

            model.FilterOption.Brands = query
                .Where(x => x.BrandId != null)
                .GroupBy(x => x.Brand)
                .Select(g => new FilterBrand
                {
                    Id = (int)g.Key.Id,
                    Name = g.Key.Name,
                    Slug = g.Key.Slug,
                    Count = g.Count()
                }).ToList();
        }
    }
}
