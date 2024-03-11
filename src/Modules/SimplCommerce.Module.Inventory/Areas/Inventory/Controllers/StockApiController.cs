using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels;
using SimplCommerce.Module.Inventory.Models;
using SimplCommerce.Module.Inventory.Services;

namespace SimplCommerce.Module.Inventory.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/stocks")]
    public class StockApiController : Controller
    {
        private readonly IRepository<Stock> _stockRepository;
        private readonly IStockService _stockService;
        private readonly IStockSubscriptionService _stockSubscriptionService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly IRepository<StockHistory> _stockHistoryRepository;
        private readonly IRepository<ProductBackInStockSubscription> _backInStockSubscriptionRepository;

        public StockApiController(IRepository<Stock> stockRepository, IStockService stockService, IWorkContext workContext, IRepository<Warehouse> warehouseRepository, IRepository<StockHistory> stockHistoryRepository, IRepository<ProductBackInStockSubscription> backInStockSubscriptionRepository, IStockSubscriptionService stockSubscriptionService)
        {
            _stockRepository = stockRepository;
            _stockService = stockService;
            _workContext = workContext;
            _warehouseRepository = warehouseRepository;
            _stockHistoryRepository = stockHistoryRepository;
            _backInStockSubscriptionRepository = backInStockSubscriptionRepository;
            _stockSubscriptionService = stockSubscriptionService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> List(long warehouseId, [FromBody] SmartTableParam param)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var warehouse = _warehouseRepository.Query().FirstOrDefault(x => x.Id == warehouseId);
            if(warehouse == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("admin") && warehouse.VendorId != currentUser.VendorId)
            {
                return BadRequest(new { error = "You don't have permission to manage this warehouse" });
            }

            var query = _stockRepository.Query().Where(x => x.WarehouseId == warehouseId && !x.Product.HasOptions && !x.Product.IsDeleted);
            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.ProductName != null)
                {
                    string productName = search.ProductName;
                    query = query.Where(x => x.Product.Name.Contains(productName));
                }

                if (search.ProductSku != null)
                {
                    string productSku = search.productSku;
                    query = query.Where(x => x.Product.Sku.Contains(productSku));
                }
            }

            var products = query.ToSmartTableResult(
                param,
                x => new
                {
                    x.Id,
                    x.ProductId,
                    ProductName = x.Product.Name,
                    ProductSku = x.Product.Sku,
                    x.Quantity,
                    AdjustedQuantity = 0
                });

            return Ok(products);
        }

        [HttpPut]
        public async Task<IActionResult> Put(long warehouseId, [FromBody] IList<StockVm> stockVms)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var warehouse = _warehouseRepository.Query().FirstOrDefault(x => x.Id == warehouseId);
            if (warehouse == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("admin") && warehouse.VendorId != currentUser.VendorId)
            {
                return BadRequest(new { error = "You don't have permission to manage this warehouse" });
            }

            foreach(var item in stockVms)
            {
                if(item.AdjustedQuantity == 0)
                {
                    continue;
                }

                var stockUpdateRequest = new StockUpdateRequest
                {
                    WarehouseId = warehouseId,
                    ProductId = item.ProductId,
                    AdjustedQuantity = item.AdjustedQuantity,
                    Note = item.Note,
                    UserId = currentUser.Id
                };

                await _stockService.UpdateStock(stockUpdateRequest);
            }

            return Accepted();
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetStockHistory(int warehouseId, int productId)
        {
            var query = _stockHistoryRepository.Query();
            query = query.Where(x => x.WarehouseId == warehouseId && x.ProductId == productId);
            var stockHistory = await query.Select(x => new
            {
                x.Id,
                x.Product.Name,
                x.CreatedOn,
                x.CreatedBy.FullName,
                x.AdjustedQuantity,
                x.Note
            }).ToListAsync();
  
            return Ok(stockHistory);
        }

        [AllowAnonymous]
        [HttpPost("back-in-stock")]
        public async Task<IActionResult> BackInStockSubscribe(long productId, string customerEmail)
        {
            if (await _backInStockSubscriptionRepository.Query()
                .AnyAsync(o => o.ProductId == productId && o.CustomerEmail == customerEmail))
            {
                return Conflict();
            }

            await _stockSubscriptionService.ProductBackInStockSubscribeAsync(productId, customerEmail);

            return Ok();
        }
    }
}
