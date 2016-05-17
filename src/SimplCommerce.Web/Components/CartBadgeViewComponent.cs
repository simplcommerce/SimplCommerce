using System;
using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Web.Components
{
    public class CartBadgeViewComponent : ViewComponent
    {
        private readonly ICartService cartService;
        private readonly UserManager<User> userManager;

        public CartBadgeViewComponent(ICartService cartService, UserManager<User> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            long? userId = null;
            Guid? guestId = null;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = long.Parse(userManager.GetUserId(HttpContext.User));
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