using System.Threading.Tasks;
using SimplCommerce.Module.Inventory.Models;

namespace SimplCommerce.Module.Inventory.Services
{
    public interface IStockService
    {
        Task AddAllProduct(Warehouse warehouse);

        Task UpdateStock(StockUpdateRequest stockUpdateRequest);
    }
}
