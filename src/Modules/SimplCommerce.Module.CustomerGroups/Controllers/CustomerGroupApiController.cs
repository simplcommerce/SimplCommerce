using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Infrastructure.Web.SmartTable;
using Microsoft.AspNetCore.Authorization;
using SimplCommerce.Module.CustomerGroups.Services;
using SimplCommerce.Module.CustomerGroups.ViewModels;

namespace SimplCommerce.Module.CustomerGroups.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/customergroups")]
    public class CustomerGroupApiController : Controller
    {
        private readonly IRepository<CustomerGroup> _customergroupRepository;
        private readonly ICustomerGroupService _customergroupService;

        public CustomerGroupApiController(IRepository<CustomerGroup> customergroupRepository, ICustomerGroupService customergroupService)
        {
            _customergroupRepository = customergroupRepository;
            _customergroupService = customergroupService;
        }

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = _customergroupRepository.Query()
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
        public IActionResult Get()
        {
            var customerGroups = _customergroupRepository.Query().Select(x => new
            {
                Id = x.Id,
                Name = x.Name
            });

            return Json(customerGroups);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var customergroup = _customergroupRepository.Query().Include(x => x.Users).FirstOrDefault(x => x.Id == id);
            var model = new CustomerGroupForm
            {
                Id = customergroup.Id,
                Name = customergroup.Name,
                Description = customergroup.Description,
                IsActive = customergroup.IsActive
            };

            return Json(model);
        }

        // TODO: Rework audit (change) history for entities that require it into SaveChanges or similar

        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroupForm model)
        {
            if (ModelState.IsValid)
            {
                var customergroup = new CustomerGroup
                {
                    Name = model.Name,
                    CreatedBy = User?.Identity?.Name,
                    UpdatedBy = User?.Identity?.Name,
                    Description = model.Description,
                    IsActive = model.IsActive
                };

                _customergroupService.Create(customergroup);

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] CustomerGroupForm model)
        {
            
            if (ModelState.IsValid)
            {
                var customergroup = _customergroupRepository.Query().FirstOrDefault(x => x.Id == id);
                customergroup.Name = model.Name;
                customergroup.Description = model.Description;
                customergroup.IsActive = model.IsActive;
                customergroup.UpdatedOn = DateTimeOffset.Now;
                customergroup.UpdatedBy = User?.Identity?.Name;

                _customergroupService.Update(customergroup);

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var customergroup = _customergroupRepository.Query().FirstOrDefault(x => x.Id == id);
            if (customergroup == null)
            {
                return new NotFoundResult();
            }

            _customergroupService.Delete(customergroup);
            return Json(true);
        }
    }
}
