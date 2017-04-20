using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.ProductComparison.Models;
using SimplCommerce.Module.ProductComparison.Services;
using SimplCommerce.Module.ProductComparison.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.ProductComparison.Controllers
{
    public class ProductComparisonController : Controller
    {
        private readonly IRepository<ProductComparisonItem> _productComparisonRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IProductComparisonService _productComparisonService;
        private readonly IMediaService _mediaService;
        private readonly IWorkContext _workContext;

        public ProductComparisonController(
            UserManager<User> userManager,
            IRepository<ProductComparisonItem> productComparisonRepository,
            IRepository<Product> productRepository,
            IProductComparisonService productComparisonService,
            IMediaService mediaService,
            IWorkContext workContext)
        {
            _productComparisonRepository = productComparisonRepository;
            _productRepository = productRepository;
            _productComparisonService = productComparisonService;
            _mediaService = mediaService;
            _workContext = workContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddToComparison([FromBody] AddToComparisonModel model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var comparisonItem = _productComparisonService.AddToComparison(currentUser.Id, model.ProductId);

            return View();
            //return RedirectToAction("AddToCartResult", new { cartItemId = cartItem.Id });
        }
    }
}
