using System.Threading.Tasks;

namespace SimplCommerce.Module.Inventory.Services
{
    public interface IStockService
    {
        Task AddAllProduct(long warehouseId);

        Task UpdateStock(StockUpdateRequest stockUpdateRequest);
    }
}
