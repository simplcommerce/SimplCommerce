using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Controllers
{
    [Route("api/states-provinces")]
    public class StateOrProvinceApiController : Controller
    {
        private readonly IRepository<StateOrProvince> _stateOrProvinceRepository;

        public StateOrProvinceApiController(IRepository<StateOrProvince> stateOrProvinceRepository)
        {
            _stateOrProvinceRepository = stateOrProvinceRepository;
        }

        [Route("/api/countries/{countryId}/states-provinces")]
        public async Task<IActionResult> GetStatesOrProvinces(long countryId)
        {
            var statesOrProvinces = await _stateOrProvinceRepository.Query()
                .Where(x => x.CountryId == countryId)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return Ok(statesOrProvinces);
        }
    }
}
