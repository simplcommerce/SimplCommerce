using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Web.Extensions;

namespace SimplCommerce.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<User> userManager;

        public BaseController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected long CurrentUserId => long.Parse(HttpContext.User.GetUserId());

        protected async Task<User> GetCurrentUserAsync()
        {
            return await userManager.FindByIdAsync(HttpContext.User.GetUserId());
        }

        protected Guid GetGuestId()
        {
            return GuestIdentityManager.GetOrCreateGuestId(HttpContext);
        }
    }
}