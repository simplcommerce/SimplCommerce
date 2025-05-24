using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SimplCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Module.Catalog.Controllers
{
    [Area("Catalog")]
    public class FeedController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public FeedController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.Query().Include(p => p.ThumbnailImage).ToList();
            return View(products);
        }
    }
}
