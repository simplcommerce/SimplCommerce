using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentStripeV2.Areas.PaymentStripeV2.ViewModels;
using SimplCommerce.Module.PaymentStripeV2.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentStripeV2.Areas.PaymentStripeV2.Components
{
    public class StripeV2LandingViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly ICurrencyService _currencyService;

        public StripeV2LandingViewComponent(ICartService cartService, IWorkContext workContext, IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository, ICurrencyService currencyService)

        {
            _cartService = cartService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _currencyService = currencyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.StripeProviderId);
            var stripeSetting = JsonConvert.DeserializeObject<StripeV2ConfigForm>(stripeProvider.AdditionalSettings);
            var curentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(curentUser.Id);
            var zeroDecimalAmount = cart.OrderTotal;
            if(!CurrencyHelper.IsZeroDecimalCurrencies(_currencyService.CurrencyCulture))
            {
                zeroDecimalAmount = zeroDecimalAmount * 100;
            }

            var regionInfo = new RegionInfo(_currencyService.CurrencyCulture.LCID);
            var model = new StripeV2CheckoutForm();
            model.PublicKey = stripeSetting.PublicKey;
            model.Amount = (long)zeroDecimalAmount;
            model.ISOCurrencyCode = regionInfo.ISOCurrencySymbol;

            return View(this.GetViewPath(), model);
        }
    }
}
