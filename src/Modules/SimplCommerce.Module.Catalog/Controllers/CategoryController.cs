using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Controllers
{
    public class CategoryController : Controller
    {
        private const int PageSize = 20;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;

        public CategoryController(IRepository<Product> productRepository,
            IMediaService mediaService,
            IRepository<Category> categoryRepository,
            IRepository<Brand> brandRepository)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
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
                CategorySeoTitle = category.SeoTitle,
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query = _productRepository
                .Query()
                .Where(x => x.Categories.Any(c => c.CategoryId == category.Id) && x.IsPublished && x.IsVisibleIndividually);

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
            var currentPageNum = searchOption.Page <= 0 ? 1 : searchOption.Page;
            var offset = (PageSize * currentPageNum) - PageSize;
            while (currentPageNum > 1 && offset >= model.TotalProduct)
            {
                currentPageNum--;
                offset = (PageSize * currentPageNum) - PageSize;
            }

            query = query
                .Include(x => x.Brand)
                .Include(x => x.ThumbnailImage);

            query = AppySort(searchOption, query);

            var products = query
                .Select(x => new ProductThumbnail
                {
                    Id = x.Id,
                    Name = x.Name,
                    SeoTitle = x.SeoTitle,
                    Price = x.Price,
                    OldPrice = x.OldPrice,
                    ThumbnailImage = x.ThumbnailImage,
                    NumberVariation = x.ProductLinks.Count,
                    ReviewsCount = x.ReviewsCount,
                    RatingAverage = x.RatingAverage
                })
                .Skip(offset)
                .Take(PageSize)
                .ToList();

            foreach (var product in products)
            {
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
            }

            model.Products = products;
            model.CurrentSearchOption.PageSize = PageSize;
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
    }
}
