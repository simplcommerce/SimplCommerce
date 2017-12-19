using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.ShoppingCart.Services;
using SimplCommerce.Module.PaymentStripe.ViewModels;
using SimplCommerce.Infrastructure;
using System.Globalization;

namespace SimplCommerce.Module.PaymentStripe.Components
{
    public class StripeLandingViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;
        private readonly IConfiguration _configuration;

        public StripeLandingViewComponent(ICartService cartService, IWorkContext workContext, IConfiguration configuration)
        {
            _cartService = cartService;
            _workContext = workContext;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var curentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(curentUser.Id);
            var zeroDecimalAmount = cart.OrderTotal;
            if(!CurrencyHelper.IsZeroDecimalCurrencies())
            {
                zeroDecimalAmount = zeroDecimalAmount * 100;
            }

            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);
            var model = new StripeCheckoutForm();
            model.PublicKey = _configuration["Stripe:PublishableKey"];
            model.Amount = (int)zeroDecimalAmount;
            model.ISOCurrencyCode = regionInfo.ISOCurrencySymbol;

            return View("/Modules/SimplCommerce.Module.PaymentStripe/Views/Components/StripeLanding.cshtml", model);
        }
    }
}
