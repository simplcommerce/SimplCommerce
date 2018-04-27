using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/product-prices")]
    public class ProductPriceApiController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public ProductPriceApiController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("grid")]
        public IActionResult List([FromBody] SmartTableParam param)
        {
            var query = _productRepository.Query().Where(x => !x.HasOptions && !x.IsDeleted);
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
                    x.SeoTitle,
                    x.Price,
                    x.OldPrice,
                    x.SpecialPrice,
                    x.SpecialPriceStart,
                    x.SpecialPriceEnd
                });

            return Ok(products);
        }
    }
}
