using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Core.Controllers
{
    [Route("api/states-provinces")]
    public class StateOrProvinceApiController : Controller
    {
        private readonly IRepository<StateOrProvince> _stateOrProvinceRepository;
        private readonly IRepository<Country> _countryRepository;

        public StateOrProvinceApiController(IRepository<StateOrProvince> stateOrProvinceRepository, IRepository<Country> countryRepository)
        {
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _countryRepository = countryRepository;
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

        public async Task<IActionResult> Get()
        {
            var statesOrProvinces = await _stateOrProvinceRepository.Query()
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Id,
                    x.Name
                })
                .ToListAsync();

            return Ok(statesOrProvinces);
        }

        [HttpPost("grid")]
        public IActionResult List(int countryId, [FromBody] SmartTableParam param)
        {
            var query = _stateOrProvinceRepository.Query().Where(sp => sp.CountryId == countryId);

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.Name != null)
                {
                    string name = search.Name;
                    query = query.Where(x => x.Name.Contains(name));
                }
            }

            var stateProvinces = query.ToSmartTableResult(
                param,
                 sp => new
                 {
                     sp.Id,
                     sp.Name,
                     sp.Code,
                     sp.CountryCode
                 });

            return Json(stateProvinces);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var stateProvince = await _stateOrProvinceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (stateProvince == null)
            {
                return NotFound();
            }

            var model = new StateOrProvinceForm
            {
                Id = stateProvince.Id,
                Name = stateProvince.Name,
                Code = stateProvince.Code,
                CountryCode = stateProvince.CountryCode,
                CountryId = stateProvince.CountryId,
                Type = stateProvince.Type
            };

            return Json(model);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(long id, [FromBody] StateOrProvinceForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stateProvince = await _stateOrProvinceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (stateProvince == null)
            {
                return NotFound();
            }

            stateProvince.Name = model.Name;
            stateProvince.Code = model.Code;
            stateProvince.Type = model.Type;

            await _stateOrProvinceRepository.SaveChangesAsync();
            return Accepted();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] StateOrProvinceForm model)
        {
            if (ModelState.IsValid)
            {
                var country = await _countryRepository.Query().FirstOrDefaultAsync(x => x.Id == model.CountryId);
                if (country == null)
                {
                    return NotFound();
                }

                var stateProvince = new StateOrProvince
                {
                    Name = model.Name,
                    Code = model.Code,
                    CountryCode = country.Code2,
                    CountryId = country.Id,
                    Country = country,
                    Type = model.Type
                };
                _stateOrProvinceRepository.Add(stateProvince);
                await _stateOrProvinceRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = stateProvince.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var stateProvince = await _stateOrProvinceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (stateProvince == null)
            {
                return NotFound();
            }

            try
            {
                _stateOrProvinceRepository.Remove(stateProvince);
                await _stateOrProvinceRepository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { Error = $"The state or province {stateProvince.Name} can't not be deleted because it is referenced by other tables" });
            }

            return NoContent();
        }
    }
}
