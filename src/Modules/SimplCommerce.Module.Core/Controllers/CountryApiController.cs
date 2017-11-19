using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

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
    }
}
