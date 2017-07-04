using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Core.Controllers
{
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

            var users = query.ToSmartTableResult(
                param,
                user => new
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    CreatedOn = user.CreatedOn,
                    Roles = string.Join(", ", user.Roles.Select(x => x.Role.Name))
                });

            return Json(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userRepository.Query().Include(x => x.Roles).FirstOrDefault(x => x.Id == id);

            var model = new UserForm
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                VendorId = user.VendorId,
                RoleIds = user.Roles.Select(x => x.RoleId).ToList()
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

                foreach(var roleId in model.RoleIds)
                {
                    var userRole = new UserRole
                    {
                        RoleId = roleId
                    };

                    user.Roles.Add(userRole);
                    userRole.User = user;
                }

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok();
                }

                AddErrors(result);
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UserForm model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.Query().Include(x => x.Roles).FirstOrDefault(x => x.Id == id);
                user.Email = model.Email;
                user.UserName = model.Email;
                user.FullName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;
                user.VendorId = model.VendorId;
                AddOrDeleteRoles(model, user);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Ok();
                }

                AddErrors(result);
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _userRepository.Query().FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return new NotFoundResult();
            }

            user.IsDeleted = true;
            _userRepository.SaveChange();
            return Json(true);
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
