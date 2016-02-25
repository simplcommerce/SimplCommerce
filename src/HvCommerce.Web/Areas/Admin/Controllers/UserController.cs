using System.Linq;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.Areas.Admin.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace HvCommerce.Web.Areas.Admin.Controllers
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
        public ActionResult ListAjax()
        {
            var users = userRepository.Query()
                .Where(x => !x.IsDeleted)
                .Select(user => new UserListItem
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FullName = user.FullName,
                        CreatedOn = user.CreatedOn
                    });

            return Json(new { items = users, numberOfPages = 10});
        }

        public ActionResult Detail(long id)
        {
            var user = userRepository.Get(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var user = userRepository.Get(id);
            if (user == null)
            {
                return new HttpStatusCodeResult(400);
            }

            user.IsDeleted = true;
            userRepository.SaveChange();
            return Json(true);
        }
    }
}