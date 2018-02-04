using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Inventory.Models;
using SimplCommerce.Module.Inventory.ViewModels;

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

        [HttpPost("grid")]
        public IActionResult List([FromBody] SmartTableParam param)
        {
            var query = _warehouseRepository.Query();
            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.Name != null)
                {
                    string name = $"%{search.Name}%";
                    query = query.Where(x => EF.Functions.Like(x.Name, name));
                }
            }

            var warehouses = query.ToSmartTableResult(
                param,
                 sp => new
                 {
                     sp.Id,
                     sp.Name
                 });

            return Json(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var warehouse = await _warehouseRepository.Query().FirstOrDefaultAsync(w => w.Id == id);

            if(warehouse == null)
            {
                return NotFound();
            }

            var model = new WarehouseVm
            {
                Name = warehouse.Name,
                ContactName = warehouse.Address?.ContactName
            };

            return Json(model);
        }
    }
}
