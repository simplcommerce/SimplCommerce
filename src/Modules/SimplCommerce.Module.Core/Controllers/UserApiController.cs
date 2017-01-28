using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Infrastructure.Web.SmartTable;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/users")]
    public class UserApiController : Controller
    {
        private readonly IRepository<User> userRepository;

        public UserApiController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = userRepository.Query()
                .Include(x => x.Roles).ThenInclude(r => r.Role)
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
        public ActionResult Get(long id)
        {
            var user = userRepository.Query().FirstOrDefault(x => x.Id == id);

            var model = new
            {
                Id = user.Id,
                FullName = user.FullName
            };

            return Json(model);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var user = userRepository.Query().FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return new NotFoundResult();
            }

            user.IsDeleted = true;
            userRepository.SaveChange();
            return Json(true);
        }
    }
}
