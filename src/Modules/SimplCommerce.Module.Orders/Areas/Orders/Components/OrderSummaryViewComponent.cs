using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.Orders.Areas.Orders.Components
{
    public class OrderSummaryViewComponent : ViewComponent
    {
        private readonly ICheckoutService _checkoutService;
        private readonly IWorkContext _workContext;
        private ICurrencyService _currencyService;

        public OrderSummaryViewComponent(ICheckoutService checkoutService, IWorkContext workContext, ICurrencyService currencyService)
        {
            _checkoutService = checkoutService;
            _workContext = workContext;
            _currencyService = currencyService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid checkoutId)
        {
            var curentUser = await _workContext.GetCurrentUser();
            var checkout = await _checkoutService.GetCheckoutDetails(checkoutId);
            if (checkout == null)
            {
                checkout = new CheckoutVm(_currencyService);
            }
            return View(this.GetViewPath(), checkout);
        }
    }
}
