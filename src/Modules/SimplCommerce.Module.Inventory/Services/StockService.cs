using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Inventory.Models;

namespace SimplCommerce.Module.Inventory.Services
{
    public class StockService : IStockService
    {
        private readonly IRepository<Stock> _stockRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<StockHistory> _stockHistoryRepository;

        public StockService(IRepository<Stock> stockRepository, IRepository<Product> productRepository, IRepository<StockHistory> stockHistoryRepository)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
            _stockHistoryRepository = stockHistoryRepository;
        }

        public async Task AddAllProduct(Warehouse warehouse)
        {
            var products = await _productRepository.Query()
                .Where(x => !x.HasOptions && x.VendorId == warehouse.VendorId)
                .GroupJoin(_stockRepository.Query().Where(x => x.WarehouseId == warehouse.Id),
                    product => product.Id, stock => stock.ProductId,
                    (product, stock) => new { ProductId = product.Id, stock })
                .SelectMany(x => x.stock.DefaultIfEmpty(), (x, stock) => new
                {
                    x.ProductId,
                    stock.Quantity
                }).Where(x => x.Quantity !=0).ToArrayAsync();

            var stocks = products.Select(x => new Stock { ProductId = x.ProductId, WarehouseId = warehouse.Id, Quantity = 0 });
            _stockRepository.AddRange(stocks);
            await _stockRepository.SaveChangesAsync();
        }

        public async Task UpdateStock(StockUpdateRequest stockUpdateRequest)
        {
            var product = await _productRepository.Query().FirstOrDefaultAsync(x => x.Id == stockUpdateRequest.ProductId);
            var stock = await _stockRepository.Query().FirstOrDefaultAsync(x => x.ProductId == stockUpdateRequest.ProductId && x.WarehouseId == stockUpdateRequest.WarehouseId);

            stock.Quantity = stock.Quantity + stockUpdateRequest.AdjustedQuantity;
            product.StockQuantity = product.StockQuantity + stockUpdateRequest.AdjustedQuantity;
            var stockHistory = new StockHistory
            {
                ProductId = stockUpdateRequest.ProductId,
                WarehouseId = stockUpdateRequest.WarehouseId,
                AdjustedQuantity = stockUpdateRequest.AdjustedQuantity,
                Note = stockUpdateRequest.Note,
                CreatedById = stockUpdateRequest.UserId,
                CreatedOn = DateTimeOffset.Now,
            };

            _stockHistoryRepository.Add(stockHistory);
            await _stockHistoryRepository.SaveChangesAsync();
        }
    }
}
