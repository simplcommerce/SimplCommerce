using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Search.ViewModels;
using System.Linq;

namespace SimplCommerce.Module.Search.Controllers
{
    public class SearchController : Controller
    {
        private IRepository<Product> _productRepository;
        private IRepository<Brand> _brandRepository;

        public SearchController(IRepository<Product> productRepository, IRepository<Brand> brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet("search")]
        public IActionResult Index(SearchOption searchOption)
        {
            if (!string.IsNullOrWhiteSpace(searchOption.Query))
            {
                var brand = _brandRepository.Query().FirstOrDefault(x => x.Name == searchOption.Query && x.IsPublished);
                if(brand != null)
                {
                    return Redirect(string.Format("~/{0}", brand.SeoTitle));
                }
            }
            var searchResult = new SearchResult
            {
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            return View(searchResult);
        }
    }
}
