using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/product-prices")]
    public class ProductPriceApiController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IWorkContext _workContext;

        public ProductPriceApiController(IRepository<Product> productRepository, IWorkContext workContext)
        {
            _productRepository = productRepository;
            _workContext = workContext;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> List([FromBody] SmartTableParam param)
        {
            var query = _productRepository.Query().Where(x => !x.HasOptions && !x.IsDeleted);
            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                query = query.Where(x => x.VendorId == currentUser.VendorId);
            }

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.ProductName != null)
                {
                    string productName = search.ProductName;
                    query = query.Where(x => x.Name.Contains(productName));
                }

                if (search.ProductSku != null)
                {
                    string productSku = search.productSku;
                    query = query.Where(x => x.Sku.Contains(productSku));
                }
            }

            var products = query.ToSmartTableResult(
                param,
                x => new
                {
                    x.Id,
                    x.Name,
                    x.Sku,
                    x.Slug,
                    x.Price,
                    x.OldPrice,
                    x.SpecialPrice,
                    x.SpecialPriceStart,
                    x.SpecialPriceEnd
                });

            return Ok(products);
        }

        public async Task<IActionResult> Put([FromBody] IList<ProductPriceItemForm> productPriceItemForms)
        {
            var currentUser = await _workContext.GetCurrentUser();
            foreach (var item in productPriceItemForms)
            {
                if (!item.NewOldPrice.HasValue && !item.NewPrice.HasValue)
                {
                    continue;
                }

                var product = _productRepository.Query().FirstOrDefault(x => x.Id == item.Id);
                if(product != null && (User.IsInRole("admin") || product.VendorId == currentUser.VendorId))
                {
                    var productPriceHistory = new ProductPriceHistory
                    {
                        Product = product,
                        CreatedBy = currentUser,
                        OldPrice = product.OldPrice,
                        Price = product.Price,
                        SpecialPrice = product.SpecialPrice,
                        SpecialPriceStart = product.SpecialPriceStart,
                        SpecialPriceEnd = product.SpecialPriceEnd
                    };

                    if (item.NewOldPrice.HasValue)
                    {
                        product.OldPrice = productPriceHistory.OldPrice = item.NewOldPrice.Value;
                    }

                    if (item.NewPrice.HasValue)
                    {
                        product.Price = item.NewPrice.Value;
                        productPriceHistory.Price = item.NewPrice.Value;
                    }

                    product.PriceHistories.Add(productPriceHistory);
                }
            }

            await _productRepository.SaveChangesAsync();
            return Accepted();
        }
    }
}
