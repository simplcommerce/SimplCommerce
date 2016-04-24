using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Web.Extensions;

namespace Shopcuatoi.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<User> userManager;

        public BaseController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public long CurrentUserId => long.Parse(HttpContext.User.GetUserId());

        [NonAction]
        public async Task<User> GetCurrentUserAsync()
        {
            return await userManager.FindByIdAsync(HttpContext.User.GetUserId());
        }

        [NonAction]
        public Guid GetGuestId()
        {
            return GuestIdentityManager.GetGuestId(HttpContext);
        }
    }
}
