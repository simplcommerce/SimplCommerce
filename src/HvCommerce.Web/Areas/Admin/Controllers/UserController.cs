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

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListAjax([DataSourceRequest] DataSourceRequest request)
        {
            var users = userRepository.Query().Where(x => !x.IsDeleted);

            var gridData = users.ToDataSourceResult(
                request,
                user => new UserList
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    CreatedOn = user.CreatedOn
                });

            return Json(gridData);
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