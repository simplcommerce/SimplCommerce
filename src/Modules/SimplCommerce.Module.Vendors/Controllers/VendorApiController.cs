using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Vendors.Services;
using SimplCommerce.Module.Vendors.ViewModels;

namespace SimplCommerce.Module.Vendors.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/vendors")]
    public class VendorApiController : Controller
    {
        private readonly IRepository<Vendor> _vendorRepository;
        private readonly IVendorService _vendorService;

        public VendorApiController(IRepository<Vendor> vendorRepository, IVendorService vendorService)
        {
            _vendorRepository = vendorRepository;
            _vendorService = vendorService;
        }

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = _vendorRepository.Query()
                .Where(x => !x.IsDeleted);

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.Email != null)
                {
                    string email = search.Email;
                    query = query.Where(x => x.Email.Contains(email));
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

            var vendors = query.ToSmartTableResult(
                param,
                x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    IsActive = x.IsActive,
                    SeoTitle = x.SeoTitle,
                    CreatedOn = x.CreatedOn
                });

            return Json(vendors);
        }

        public IActionResult Get()
        {
            var vendors = _vendorRepository.Query().Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.SeoTitle
            });

            return Json(vendors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var vendor = _vendorRepository.Query().Include(x => x.Users).FirstOrDefault(x => x.Id == id);
            var model = new VendorForm
            {
                Id = vendor.Id,
                Name = vendor.Name,
                Slug = vendor.SeoTitle,
                Email = vendor.Email,
                Description = vendor.Description,
                IsActive = vendor.IsActive,
                Managers = vendor.Users.Select(x => new VendorManager { UserId = x.Id, Email = x.Email }).ToList()
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] VendorForm model)
        {
            if (ModelState.IsValid)
            {
                var vendor = new Vendor
                {
                    Name = model.Name,
                    SeoTitle = model.Slug,
                    Email = model.Email,
                    Description = model.Description,
                    IsActive = model.IsActive
                };

                _vendorService.Create(vendor);

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] VendorForm model)
        {
            if (ModelState.IsValid)
            {
                var vendor = _vendorRepository.Query().FirstOrDefault(x => x.Id == id);
                vendor.Name = model.Name;
                vendor.SeoTitle = model.Slug;
                vendor.Email = model.Email;
                vendor.Description = model.Description;
                vendor.IsActive = model.IsActive;
                vendor.UpdatedOn = DateTimeOffset.Now;

                _vendorService.Update(vendor);

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var vendor = _vendorRepository.Query().FirstOrDefault(x => x.Id == id);
            if (vendor == null)
            {
                return new NotFoundResult();
            }

            await _vendorService.Delete(vendor);
            return Json(true);
        }
    }
}
