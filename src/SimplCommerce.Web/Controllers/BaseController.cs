using System;
using System.Threading.Tasks;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace SimplCommerce.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<User> userManager;

        public BaseController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected long CurrentUserId => long.Parse(userManager.GetUserId(HttpContext.User));

        protected async Task<User> GetCurrentUserAsync()
        {
            return await userManager.GetUserAsync(HttpContext.User);
        }

        protected Guid GetGuestId()
        {
            return GuestIdentityManager.GetOrCreateGuestId(HttpContext);
        }
    }
}