using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels;
using SimplCommerce.Web.Areas.Admin.ViewModels.SmartTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IRepository<User> userRepository;

        public UserController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = userRepository.Query().Where(x => !x.IsDeleted);

            var users = query.ToSmartTableResult(
                param,
                user => new UserListItem
                 {
                     Id = user.Id,
                     Email = user.Email,
                     FullName = user.FullName,
                     CreatedOn = user.CreatedOn
                 });

            return Json(users);
        }

        public ActionResult Detail(long id)
        {
            var user = userRepository.Query().FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
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