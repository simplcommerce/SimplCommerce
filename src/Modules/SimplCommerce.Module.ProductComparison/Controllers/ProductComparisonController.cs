using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using System.Linq;
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
        private readonly int MaxComparisonItem = 4;

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

            var comparisonItems = _productComparisonService.GetComparisonItems(currentUser.Id);

            if (comparisonItems.Count >= MaxComparisonItem)
            {
                return RedirectToAction("AddToComparisonResult", new { addItemResult = false });
            }

            var comparisonItem = _productComparisonService.AddToComparison(currentUser.Id, model.ProductId);

            return RedirectToAction("AddToComparisonResult", new { addItemResult = true });
        }

        [HttpGet]
        public async Task<IActionResult> AddToComparisonResult(bool addItemResult = false)
        {
            var currentUser = await _workContext.GetCurrentUser();

            var comparisonItems = _productComparisonService.GetComparisonItems(currentUser.Id)
                .Select(x => new ProductComparisonModel()
                {
                    ProductName = x.Product.Name,
                    ProductImage = _mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                    ProductPrice = x.Product.Price,
                    ProductId = x.ProductId
                }
                ).ToList();

            var model = new AddToComparisonResult
            {
                MaxItem = MaxComparisonItem,
                ProductComparisons = comparisonItems,
                ComparisonItemCount = comparisonItems.Count,
                AddResult = addItemResult
            };

            if (addItemResult)
            {
                model.Message = "The product has been added to comparison items";
            }
            else
            {
                model.Message = "Can not add to comparison items. Can only comparison "+ MaxComparisonItem + " items";
            }

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromComparison(long productId)
        {
            var currentUser = await _workContext.GetCurrentUser();

            var productComparison = _productComparisonRepository.Query().FirstOrDefault(x => x.UserId == currentUser.Id && x.ProductId == productId);

            if (productComparison == null)
            {
                return new NotFoundResult();
            }

            _productComparisonRepository.Remove(productComparison);
            _productComparisonRepository.SaveChange();

            return Json(true);            
        }
    }
}
