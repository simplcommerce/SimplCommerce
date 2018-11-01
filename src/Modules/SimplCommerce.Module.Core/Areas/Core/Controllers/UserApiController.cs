using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    [Authorize(Roles = "admin")]
    [Route("api/users")]
    public class UserApiController : Controller
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;

        public UserApiController(IRepository<User> userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpPost("grid")]
        public IActionResult List([FromBody] SmartTableParam param)
        {
            var query = _userRepository.Query()
                .Include(x => x.Roles)
                    .ThenInclude(x => x.Role)
                .Include(x => x.CustomerGroups)
                    .ThenInclude(x => x.CustomerGroup)
                .Where(x => !x.IsDeleted);

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.Email != null)
                {
                    string email = search.Email;
                    query = query.Where(x => x.Email.Contains(email));
                }

                if (search.FullName != null)
                {
                    string fullName = search.FullName;
                    query = query.Where(x => x.FullName.Contains(fullName));
                }

                if (search.RoleId != null)
                {
                    long roleId = search.RoleId;
                    query = query.Where(x => x.Roles.Any(r => r.RoleId == roleId));
                }

                if (search.CustomerGroupId != null)
                {
                    long customerGroupId = search.CustomerGroupId;
                    query = query.Where(x => x.CustomerGroups.Any(g => g.CustomerGroupId == customerGroupId));
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

            var users = query.ToSmartTableResultNoProjection(
                param,
                user => new
                {
                    user.Id,
                    user.Email,
                    user.FullName,
                    user.CreatedOn,
                    Roles = user.Roles.Select(x => x.Role.Name),
                    CustomerGroups = user.CustomerGroups.Select(x => x.CustomerGroup.Name)
                });

            return Json(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var user = await _userRepository.Query()
                .Include(x => x.Roles)
                .Include(x => x.CustomerGroups)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(user == null)
            {
                return NotFound();
            }

            var model = new UserForm
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                VendorId = user.VendorId,
                RoleIds = user.Roles.Select(x => x.RoleId).ToList(),
                CustomerGroupIds = user.CustomerGroups.Select(x => x.CustomerGroupId).ToList()
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserForm model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    VendorId = model.VendorId
                };

                foreach (var roleId in model.RoleIds)
                {
                    var userRole = new UserRole
                    {
                        RoleId = roleId
                    };

                    user.Roles.Add(userRole);
                    userRole.User = user;
                }

                foreach (var customergroupId in model.CustomerGroupIds)
                {
                    var userCustomerGroup = new CustomerGroupUser
                    {
                        CustomerGroupId = customergroupId
                    };
                }

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return CreatedAtAction(nameof(Get), new { id = user.Id }, null);
                }

                AddErrors(result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UserForm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.Query()
                    .Include(x => x.Roles)
                    .Include(x => x.CustomerGroups)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if(user == null)
                {
                    return NotFound();
                }

                user.Email = model.Email;
                user.UserName = model.Email;
                user.FullName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;
                user.VendorId = model.VendorId;
                AddOrDeleteRoles(model, user);
                AddOrDeleteCustomerGroups(model, user);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Accepted();
                }

                AddErrors(result);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await _userRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;
            await _userRepository.SaveChangesAsync();
            return NoContent();
        }

        private void AddOrDeleteRoles(UserForm model, User user)
        {
            foreach (var roleId in model.RoleIds)
            {
                if (user.Roles.Any(x => x.RoleId == roleId))
                {
                    continue;
                }

                var userRole = new UserRole
                {
                    RoleId = roleId,
                    User = user
                };
                user.Roles.Add(userRole);
            }

            var deletedUserRoles =
                user.Roles.Where(userRole => !model.RoleIds.Contains(userRole.RoleId))
                    .ToList();

            foreach (var deletedUserRole in deletedUserRoles)
            {
                deletedUserRole.User = null;
                user.Roles.Remove(deletedUserRole);
            }
        }

        private void AddOrDeleteCustomerGroups(UserForm model, User user)
        {
            foreach (var customergroupId in model.CustomerGroupIds)
            {
                if (user.CustomerGroups.Any(x => x.CustomerGroupId == customergroupId))
                {
                    continue;
                }

                var userCustomerGroup = new CustomerGroupUser
                {
                    CustomerGroupId = customergroupId,
                    User = user
                };
                user.CustomerGroups.Add(userCustomerGroup);
            }

            var deletedUserCustomerGroups =
                user.CustomerGroups.Where(userCustomerGroup => !model.CustomerGroupIds.Contains(userCustomerGroup.CustomerGroupId))
                    .ToList();

            foreach (var deletedUserCustomerGroup in deletedUserCustomerGroups)
            {
                deletedUserCustomerGroup.User = null;
                user.CustomerGroups.Remove(deletedUserCustomerGroup);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
