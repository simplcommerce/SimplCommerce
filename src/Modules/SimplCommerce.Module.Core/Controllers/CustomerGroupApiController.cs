using System;
using System.Data.SqlClient;
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
        private readonly IRepository<CustomerGroup> _customergroupRepository;

        public CustomerGroupApiController(IRepository<CustomerGroup> customergroupRepository)
        {
            _customergroupRepository = customergroupRepository;
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
        public async Task<IActionResult> Get(long id)
        {
            var customergroup = await _customergroupRepository.Query().Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == id);
            var model = new CustomerGroupForm
            {
                Id = customergroup.Id,
                Name = customergroup.Name,
                Description = customergroup.Description,
                IsActive = customergroup.IsActive
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroupForm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customergroup = new CustomerGroup
                    {
                        Name = model.Name,
                        Description = model.Description,
                        IsActive = model.IsActive
                    };

                    _customergroupRepository.Add(customergroup);
                    _customergroupRepository.SaveChange();
                    return Ok();
                }
            }
            catch (DbUpdateException ex)
            {
                if (ExceptionHelper.IsUniqueConstraintViolation(ex))
                {
                    ModelState.AddModelError("Name", $"The Name '{model.Name}' is already in use, please enter a different name.");
                    return new BadRequestObjectResult(ModelState);
                }

                throw;
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CustomerGroupForm model)
        {

            if (ModelState.IsValid)
            {
                var customergroup = await _customergroupRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                customergroup.Name = model.Name;
                customergroup.Description = model.Description;
                customergroup.IsActive = model.IsActive;
                customergroup.UpdatedOn = DateTimeOffset.Now;

                try
                {
                    _customergroupRepository.SaveChange();
                    return Ok();
                }
                catch (DbUpdateException ex)
                {
                    if (ExceptionHelper.IsUniqueConstraintViolation(ex))
                    {
                        ModelState.AddModelError("Name", $"The Name '{model.Name}' is already in use, please enter a different name.");
                        return new BadRequestObjectResult(ModelState);
                    }

                    throw;
                }
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var customergroup = await _customergroupRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (customergroup == null)
            {
                return new NotFoundResult();
            }

            customergroup.IsDeleted = true;
            _customergroupRepository.SaveChange();
            return Json(true);
        }
    }

    public static class ExceptionHelper
    {
        private static Exception GetInnermostException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        public static bool IsUniqueConstraintViolation(Exception ex)
        {
            var innermost = GetInnermostException(ex);
            var sqlException = innermost as SqlException;

            return sqlException != null && sqlException.Class == 14 && (sqlException.Number == 2601 || sqlException.Number == 2627);
        }
    }
}
