using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Core.Controllers
{
    [Route("api/countries")]
    public class CountryApiController : Controller
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryApiController(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IActionResult> Get([FromQuery]bool? shippingEnabled)
        {
            var query = _countryRepository.Query();
            if (shippingEnabled.HasValue)
            {
                query = query.Where(x => x.IsShippingEnabled == shippingEnabled.Value);
            }
            var countries = await query
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
            return Json(countries);
        }

        [HttpPost("grid")]
        public IActionResult List([FromBody] SmartTableParam param)
        {
            var query = _countryRepository.Query();

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.Name != null)
                {
                    string name = search.Name;
                    query = query.Where(x => x.Name.Contains(name));
                }
            }

            var countries = query.ToSmartTableResult(
                param,
                c => new
                {
                    c.Id,
                    c.Name,
                    c.IsShippingEnabled
                });

            return Json(countries);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CountryForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = await _countryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(country == null)
            {
                return NotFound();
            }

            country.IsShippingEnabled = model.IsShippingEnabled;
            await _countryRepository.SaveChangesAsync();
            return Accepted();
        }
    }
}
