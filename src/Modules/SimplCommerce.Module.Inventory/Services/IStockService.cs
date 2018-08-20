using SimplCommerce.Module.Inventory.Models;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Inventory.Services
{
    public interface IStockService
    {
        Task AddAllProduct(Warehouse warehouse);

        Task UpdateStock(StockUpdateRequest stockUpdateRequest);
    }
}
