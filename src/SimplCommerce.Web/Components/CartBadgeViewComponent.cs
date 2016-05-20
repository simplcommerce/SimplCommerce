using System;
using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SimplCommerce.Core.Domain.Models;
using System.Threading.Tasks;

namespace SimplCommerce.Web.Components
{
    public class CartBadgeViewComponent : ViewComponent
    {
        private readonly ICartService cartService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public CartBadgeViewComponent(ICartService cartService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            long? userId = null;
            Guid? guestId = null;

            if (signInManager.IsSignedIn(HttpContext.User))
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                userId = user.Id;
            }
            else
            {
                guestId = GuestIdentityManager.GetGuestId(HttpContext);
            }

            var cartItemCount = cartService.GetCartItems(userId, guestId).Count;

            return View(cartItemCount);
        }
    }
}