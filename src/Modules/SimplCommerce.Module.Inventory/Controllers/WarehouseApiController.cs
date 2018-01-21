using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Inventory.Models;

namespace SimplCommerce.Module.Inventory.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/warehouses")]
    public class WarehouseApiController : Controller
    {
        private readonly IRepository<Warehouse> _warehouseRepository;

        public WarehouseApiController(IRepository<Warehouse> warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<IActionResult> Get()
        {
            var warehouses = await _warehouseRepository.Query().Select(x => new
            {
                x.Id,
                x.Name
            }).ToListAsync();

            return Ok(warehouses);
        }
    }
}
