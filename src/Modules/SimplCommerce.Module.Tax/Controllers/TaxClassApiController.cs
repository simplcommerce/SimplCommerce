using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Tax.Models;
using SimplCommerce.Module.Tax.ViewModels;

namespace SimplCommerce.Module.Tax.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/tax-classes")]
    public class TaxClassApiController : Controller
    {
        private readonly IRepository<TaxClass> _taxClassRepository;

        public TaxClassApiController(IRepository<TaxClass> taxClassRepository)
        {
            _taxClassRepository = taxClassRepository;
        }

        public async Task<IActionResult> Get()
        {
            var taxClasses = await _taxClassRepository
                .Query()
                .Select(x => new { Id = x.Id, Name = x.Name })
                .ToListAsync();
            return Json(taxClasses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var taxClass = await _taxClassRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(taxClass == null)
            {
                return NotFound();
            }

            var model = new TaxClassForm
            {
                Id = taxClass.Id,
                Name = taxClass.Name,
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaxClassForm model)
        {
            if (ModelState.IsValid)
            {
                var tagClass = new TaxClass
                {
                    Name = model.Name
                };

                _taxClassRepository.Add(tagClass);
                await _taxClassRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = tagClass.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] TaxClassForm model)
        {
            if (ModelState.IsValid)
            {
                var taxClass = await _taxClassRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if (taxClass == null)
                {
                    return NotFound();
                }

                taxClass.Name = model.Name;
                await _taxClassRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var taxClass = await _taxClassRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (taxClass == null)
            {
                return NotFound();
            }

            _taxClassRepository.Remove(taxClass);
            await _taxClassRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
