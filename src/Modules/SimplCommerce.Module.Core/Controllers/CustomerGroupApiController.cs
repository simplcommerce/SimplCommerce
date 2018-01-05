using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/customergroups")]
    public class CustomerGroupApiController : Controller
    {
        private readonly IRepository<CustomerGroup> _customerGroupRepository;

        public CustomerGroupApiController(IRepository<CustomerGroup> customergroupRepository)
        {
            _customerGroupRepository = customergroupRepository;
        }

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = _customerGroupRepository.Query()
                .Where(x => !x.IsDeleted);

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.Name != null)
                {
                    string name = search.Name;
                    query = query.Where(x => x.Name.Contains(name));
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        query = query.Where(x => x.CreatedOn >= after);
                    }
                }
            }

            var customerGroups = query.ToSmartTableResult(
                param,
                x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive = x.IsActive,
                    CreatedOn = x.CreatedOn
                });

            return Json(customerGroups);
        }

        public async Task<IActionResult> Get()
        {
            var customerGroups = await _customerGroupRepository.Query().Select(x => new
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return Json(customerGroups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var customerGroup = await _customerGroupRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(customerGroup == null)
            {
                return NotFound();
            }

            var model = new CustomerGroupForm
            {
                Id = customerGroup.Id,
                Name = customerGroup.Name,
                Description = customerGroup.Description,
                IsActive = customerGroup.IsActive
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerGroupForm model)
        {
            if (ModelState.IsValid)
            {
                var customerGroup = new CustomerGroup
                {
                    Name = model.Name,
                    Description = model.Description,
                    IsActive = model.IsActive
                };

                _customerGroupRepository.Add(customerGroup);
                await _customerGroupRepository.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = customerGroup.Id }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CustomerGroupForm model)
        {
            if (ModelState.IsValid)
            {
                var customerGroup = await _customerGroupRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if(customerGroup == null)
                {
                    return NotFound();
                }

                customerGroup.Name = model.Name;
                customerGroup.Description = model.Description;
                customerGroup.IsActive = model.IsActive;
                customerGroup.UpdatedOn = DateTimeOffset.Now;

                await  _customerGroupRepository.SaveChangesAsync();
                return Accepted();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var customerGroup = await _customerGroupRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (customerGroup == null)
            {
                return NotFound();
            }

            customerGroup.IsDeleted = true;
            await  _customerGroupRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
